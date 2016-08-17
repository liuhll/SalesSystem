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
    public class BrandServiceInfoMapEventHandler : IEventHandler<BrandServiceInfoMapEventData>, ITransientDependency
    {
        private readonly IServiceInfoRepository _serviceInfoRepository;

        public BrandServiceInfoMapEventHandler(IServiceInfoRepository serviceInfoRepository)
        {
            _serviceInfoRepository = serviceInfoRepository;
        }


        public  void HandleEvent(BrandServiceInfoMapEventData eventData)
        {
            var serviceInfos =  _serviceInfoRepository.GetAllList().Where(p => p.BrandId == eventData.Entity.Id).ToList();

            eventData.ServiceInfos = serviceInfos;

        }
    }
}
