using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Jeuci.SalesSystem.Entities
{
    public class ServiceInfo : Entity<int>
    {
        private bool m_isTriggerEvent = false;
        public string ServiceName { get; set; }

        public int BrandId { get; set; }

        public virtual BrandInfo BrandInfo { get; set; }

        public int State { get; set; }

        public string Remarks { get; set; }

        public int Sort { get; set; }

        //   private IList<ServicePrice> _servicePrices;

#region 扩展属性
        public virtual ICollection<ServicePrice> ServicePrices {
            //get
            //{
            //    if (!m_isTriggerEvent)
            //    {
            //        var servicePriceEventData = new ServiceInfoServicePriceMapEventData(this);
            //        EventBus.Default.Trigger(servicePriceEventData);
            //        _servicePrices = servicePriceEventData.ServicePrices;
            //        m_isTriggerEvent = true;
            //    }
            //    return _servicePrices;
            //}
            get; set;
        }

        public virtual ICollection<UserServiceSubscriptionInfo> UserServiceSubscriptionInfos { get; set; }

        #endregion
    }
}
