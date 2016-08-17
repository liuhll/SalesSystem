using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Jeuci.SalesSystem.Entities.EventData;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Events.EventHandler
{
    public class ServiceInfoServicePriceMapEventHandler : IEventHandler<ServiceInfoServicePriceMapEventData>, ITransientDependency
    {
        private readonly IServicePriceRepository _servicePriceRepository;
        public ServiceInfoServicePriceMapEventHandler(IServicePriceRepository servicePriceRepository)
        {
            _servicePriceRepository = servicePriceRepository;
        }

        public void HandleEvent(ServiceInfoServicePriceMapEventData eventData)
        {
            var servicePriceInfo = _servicePriceRepository.GetAll();
            eventData.ServicePrices = servicePriceInfo.Where(p=>p.ServiceId == eventData.Entity.Id).ToList();
        }
    }
}
