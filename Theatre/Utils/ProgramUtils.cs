using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Utils
{
    class ProgramUtils
    {

        public static string GetMySqlConnectionString()
        {

            StreamReader sr = new StreamReader("mysql.txt");

            if (!sr.EndOfStream)
            {

                return sr.ReadLine();

            }

            return "";

        }

    }
}
