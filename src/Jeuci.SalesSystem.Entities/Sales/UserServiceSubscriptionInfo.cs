using System;
using Abp.Domain.Entities;
using Abp.Runtime.Session;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Entities
{
    public class UserServiceSubscriptionInfo : Entity<string>
    {
        public UserServiceSubscriptionInfo()
        {
            CreateTime = DateTime.Now;      
        }

        public  int UId { get; set; }
  
        public  int SId { get; set; }
      
        public decimal Cost { get; set; }

        public decimal Profit { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? AuthExpiration { get; set; }

        public string Remarks { get; set; }

        public OrderState State { get; set; }

        public int AuthType { get; set; }

        public int? AgentId { get; set; }
      
        public  int? AdminId { get; set; }      

        public  int? Puid { get; set; }

        public string OrderId { get; set; }

        #region 扩展属性

        public virtual UserInfo User { get; set; }

        public virtual ServiceInfo ServiceInfo { get; set; }

        public virtual AgentInfo AgentInfo { get; set; }

        public virtual AdministratorInfo Administrator { get; set; }

        #endregion
    }
}
