using System;
using Abp.Domain.Entities;
using Jeuci.SalesSystem.Entities.Common.Helpers;

namespace Jeuci.SalesSystem.Entities
{
    public class AdminLoginHistory : Entity<int>
    {
        public AdminLoginHistory()
        {
            LoginTime = DateTime.Now;
            Ip = IpHelper.GetIpv4Address();
        }

        public int AdminId { get; set; }

        public string Ip { get; protected set; }

        public DateTime LoginTime { get; protected set; }

        public string LogInfo { get; set; }

    }
}
