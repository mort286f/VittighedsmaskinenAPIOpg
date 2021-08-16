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
        [HttpGet("GetAllJokes")]
        public IEnumerable<Joke> GetJokes()
        {
            Debug.WriteLine(Request.Headers["Accept-Language"]);
            return DALJokeClass.daJokes;
        }

        [HttpGet("GetRandomJoke")]
        public Joke GetRandomJoke(string category)
        {

            //Checks from the Accept-Language what the prefered language is
            string lang = Request.Headers["Accept-Language"].ToString();
            //splits each language up, so their values can be checked
            string[] langArray = lang.Split(',');
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
                    tempJokes = DALJokeClass.daJokes.Where(x => x.Category == category).ToList();
                }
                else if (prefLang == "en")
                {
                    tempJokes = DALJokeClass.enJokes.Where(x => x.Category == category).ToList();
                }
                Joke joke = tempJokes[rndm.Next(1, tempJokes.Count())];
                if (prefLang == "da")
                {
                    DALJokeClass.daJokes.Remove(joke);
                }
                else if (prefLang == "en")
                {
                    DALJokeClass.enJokes.Remove(joke);
                }
                HttpContext.Session.SetObjectAsJson("rndmJoke", joke);
                Joke rndmJoke = HttpContext.Session.GetObjectFromJson<Joke>("rndmJoke");
                return rndmJoke;
            }

            //if theres no search criteria
            else
            {
                Joke joke;
                if (prefLang == "da")
                {
                    joke = DALJokeClass.daJokes[rndm.Next(1, DALJokeClass.daJokes.Count)];
                    HttpContext.Session.SetObjectAsJson("rndmJoke", joke);
                    DALJokeClass.daJokes.Remove(joke);
                }
                else if (prefLang == "en")
                {
                    joke = DALJokeClass.enJokes[rndm.Next(1, DALJokeClass.enJokes.Count)];
                    HttpContext.Session.SetObjectAsJson("rndmJoke", joke);
                    DALJokeClass.enJokes.Remove(joke);
                }

                Joke rndmJoke = HttpContext.Session.GetObjectFromJson<Joke>("rndmJoke");
                return rndmJoke;
            }
        }
    }
}
