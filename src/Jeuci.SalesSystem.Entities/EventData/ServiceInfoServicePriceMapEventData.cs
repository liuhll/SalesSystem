using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Entities.EventData
{
    public class ServiceInfoServicePriceMapEventData : EntityEventData<ServiceInfo>
    {
        public ServiceInfoServicePriceMapEventData(ServiceInfo entity) : base(entity)
        {
        }

        public IList<ServicePrice> ServicePrices { get; set; }
    }
}
