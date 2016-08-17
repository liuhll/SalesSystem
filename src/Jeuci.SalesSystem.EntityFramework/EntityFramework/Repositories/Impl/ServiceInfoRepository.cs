using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Abp.Events.Bus;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.EventData;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.EntityFramework.Repositories.Impl
{
    public class ServiceInfoRepository : SalesSystemRepositoryBase<ServiceInfo>, IServiceInfoRepository
    {
        public ServiceInfoRepository(IDbContextProvider<SalesSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        //public override ServiceInfo Get(int id)
        //{
        //    var serviceInfo = base.Get(id);
        //    var brandServiceInfoMapEventData = new ServiceInfoServicePriceMapEventData(serviceInfo);
        //    EventBus.Default.Trigger(brandServiceInfoMapEventData);
        //    serviceInfo.ServicePrices = brandServiceInfoMapEventData.ServicePrices;
        //    return serviceInfo;
        //}
    }
}
