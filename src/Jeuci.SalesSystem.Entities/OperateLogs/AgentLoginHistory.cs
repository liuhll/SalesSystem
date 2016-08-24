using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Jeuci.SalesSystem.Entities.Common.Helpers;

namespace Jeuci.SalesSystem.Entities
{
    public class AgentLoginHistory : Entity<int>
    {
        public AgentLoginHistory()
        {
            LoginTime = DateTime.Now;
            Ip = IpHelper.GetIpv4Address();
        }

        public int AgentId { get; set; }

        public string Ip { get; protected set; }

        public DateTime LoginTime { get; protected set; }

        public string LogInfo { get; set; }
    }
}
