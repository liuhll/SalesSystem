using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Jeuci.SalesSystem.AdminWeb.Views
{
    public static class UrlChecker
    {
        private static readonly Regex UrlWithProtocolRegex = new Regex("^.{1,10}://.*$");

        public static bool IsRooted(string url)
        {
            if (url.StartsWith("/"))
            {
                return true;
            }

            if (UrlWithProtocolRegex.IsMatch(url))
            {
                return true;
            }

            return false;
        }
    }
}