using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Helper
{
    public static class ToolHelper
    {
        public static string GetRandomString(int digitNum)
        {
            Random rd = new Random();
            string str = string.Empty;
            while (str.Length < digitNum)
            {
                int temp = rd.Next(0, 10);
                if (!str.Contains(temp + ""))
                {
                    str += temp;
                }
            }
            return str;
        }

        public static string GetServiceSeedLine()
        {           
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            var seedNum = (int)(DateTime.Now - startTime).TotalSeconds;
            return seedNum.ToString().PadLeft(5, '0');
        }
    }
}
