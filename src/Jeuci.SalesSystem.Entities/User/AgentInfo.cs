using System;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Jeuci.SalesSystem.Entities
{
    public class AgentInfo: Entity
    {
        public AgentInfo()
        {
            UserId = Id;
        }

        public int UserId { get; set; }

        public DateTime CreateTime { get; set; }

        public int State { get; set; }

        public decimal Discount { get; set; }

        public string AgentType { get; set; }

        public string AuthType { get; set; }

        public string Website { get; set; }

        #region 扩展属性

        public virtual ICollection<UserServiceSubscriptionInfo> UserServiceSubscriptionInfos { get; set; }

        #endregion

    }
}
