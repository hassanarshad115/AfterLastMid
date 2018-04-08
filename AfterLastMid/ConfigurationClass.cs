using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterLastMid
{
    class ConfigurationClass
    {
        public static string ConfigurationMethod()
        {
            string conn;
            conn = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            return conn;
        }
    }
}
