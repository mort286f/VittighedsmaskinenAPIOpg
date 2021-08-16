using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen
{
    public class DALJokeClass
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
    }
}
