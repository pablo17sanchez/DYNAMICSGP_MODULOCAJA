using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITCASH_EXE_PS.INTREGATIONSCONTROLLERS
{
    class clsLogic
    {
        public string ConvertDatetoString(DateTime date)
        {
            string str1 = date.Year.ToString().Substring(2, 2);
            string str2 = date.Month.ToString();
            if (str2.Length == 1)
                str2 = "0" + str2;
            return str2 + str1;
        }

        public string sChangeDBFromConnString(string sConnString, string sDbToReturn)
        {
            int length = sConnString.IndexOf("Initial");
            return sConnString.Substring(0, length) + "Initial Catalog=" + sDbToReturn;
        }

        public string sBuildConnString(string sServerName, string sDBName, string sUserName, string sPassword)
        {
            string str;
            if (sUserName == "" || sPassword == "")
                str = "Integrated Security=SSPI;Persist Security Info=False;";
            else
                str = "Password=" + sPassword + ";Persist Security Info=True;User ID=" + sUserName + ";";
            return str + "Data Source=" + sServerName + ";Initial Catalog=" + sDBName;
        }






    }
}
