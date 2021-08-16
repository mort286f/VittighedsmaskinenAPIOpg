using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen
{
    //Api key class. I didnt get this implemented
    public class ApiKeyClass
    {
        public static string ApiKey = "coolApiKey";

        public bool CheckKey(string key)
        {
            if (ApiKey == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
