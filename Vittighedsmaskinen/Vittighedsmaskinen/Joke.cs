using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen
{
    public class Joke
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Line { get; set; }
        public string Pun { get; set; }

        public Joke()
        {

        }
        public Joke(int id, string category, string line, string pun)
        {
            this.ID = id;
            this.Category = category;
            this.Line = line;
            this.Pun = pun;
        }
    }
}
