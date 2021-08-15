using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Vittighedsmaskinen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        public static List<Joke> daJokes = new List<Joke>()
        {
            new Joke(1, "GoodJokes", "Hvorfor (gå) over for grønt?", "Når man kan blive (kørt) over for rødt?"),
            new Joke(2, "GoodJokes", "Hvorfor får fangerne i Norge ikke lov til at bruge internettet?", "Man er bange for at nogen skal sende dem en e-mail med en fil i"),
            new Joke(3, "GoodJokes", "Ekspedienten hos slagteren er 1.80 høj og bruger størrelse 39 i sko. Hvad vejer han?", "Han vejer kød"),
            new Joke(4, "BirdJokes", "Hvad er mågers ynglings tv program?", "Go’ mågen Danmark"),
            new Joke(5, "BirdJokes", "Hvor hurtigt flyver en måge?", "Den flyver ikke særlig hurtig, fordi den flyver i slowmågetion"),
            new Joke(6, "BirdJokes", "Hvor tager duer på ferie?", "Duebai"),
            new Joke(7, "BirdJokes", "Hvad er en måges yndlingsredskab i matematik?", "En vinkelmågler"),
            new Joke(8, "KnockKnockJokes", "Banke banke på. Hvem der? - Leif. Leif hvem?", "- Leif is Leif lo lo lo lo lo."),
            new Joke(9, "KnockKnockJokes", "Banke banke på. Hvem er det? - Kamma. Kamma hvem?", "- Kamma Kamma Kamma Kamma Chameleon"),
            new Joke(10, "KnockKnockJokes", "Banke banke på. Hvem der? - Poul! Poul hvem?", "- Poul loftet sidder nissen")
    };

        public static List<Joke> enJokes = new List<Joke>()
        {
            new Joke(1, "GoodJokes", "I'm afraid for the calendar.", "Its days are numbered"),
            new Joke(2, "GoodJokes", "My wife said I should do lunges to stay in shape", "That would be a big step forward"),
            new Joke(3, "GoodJokes", "I don't trust stairs.", "They're always up to something")
        };

        [HttpGet("GetAllJokes")]
        public IEnumerable<Joke> GetJokes()
        {
            Debug.WriteLine(Request.Headers["Accept-Language"]);
            return daJokes;
        }

        [HttpGet("GetRandomJoke")]
        public Joke GetRandomJoke(string category)
        {
            //Checks from the Accept-Language what the prefered language is
            var lang = Request.Headers["Accept-Language"];
            string tempLang = lang;
            //splits each language up, so their values can be checked
            string[] langArray = tempLang.Split(',');
            string prefLang = "";
            foreach (var languages in langArray)
            {
                //Checks after the language string if it has the value 0.9 
                if (languages.Contains("0.9"))
                {
                    //gets the first two values in the string, which is the laguage ie. "da" or "en" for example
                    prefLang = languages.Remove(2, languages.Length - 2);
                }
            }

            //If the category parameter contains a search criteria
            Random rndm = new Random();
            if (!String.IsNullOrEmpty(category))
            {
                List<Joke> tempJokes = new List<Joke>();
                if (prefLang == "da")
                {
                    tempJokes = daJokes.Where(x => x.Category == category).ToList();
                }
                else if (prefLang == "en")
                {
                    tempJokes = enJokes.Where(x => x.Category == category).ToList();
                }
                Joke joke = tempJokes[rndm.Next(1, tempJokes.Count())];
                daJokes.Remove(joke);
                HttpContext.Session.SetObjectAsJson("rndmJoke", joke);
                Joke rndmJoke = HttpContext.Session.GetObjectFromJson<Joke>("rndmJoke");
                return rndmJoke;
            }

            //if theres no search criteria
            else
            {
                if (prefLang == "da")
                {
                    HttpContext.Session.SetObjectAsJson("rndmJoke", daJokes[rndm.Next(1, daJokes.Count)]);
                }
                else if (prefLang == "en")
                {
                    HttpContext.Session.SetObjectAsJson("rndmJoke", enJokes[rndm.Next(1, enJokes.Count)]);
                }
                Joke rndmJoke = HttpContext.Session.GetObjectFromJson<Joke>("rndmJoke");
                return rndmJoke;
            }
        }
    }
}
