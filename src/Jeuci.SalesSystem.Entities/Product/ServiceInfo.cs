using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Events.Bus;
using Jeuci.SalesSystem.Entities.EventData;

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

        public virtual IList<ServicePrice> ServicePrices {
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
    }
}
