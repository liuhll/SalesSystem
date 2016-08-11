using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities.Common.Helpers
{
    public static class IpHelper
    {
        public static string GetIpv4Address()
        {
            var hostName = Dns.GetHostName();
            var ip = string.Empty;
            IPAddress[] ipadrlist = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    ip = ipa.ToString();
            }
            return ip;
        }
    }
}
