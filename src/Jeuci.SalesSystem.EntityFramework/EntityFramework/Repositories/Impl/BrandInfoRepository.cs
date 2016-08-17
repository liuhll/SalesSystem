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
    public class BrandInfoRepository : SalesSystemRepositoryBase<BrandInfo>, IBrandInfoRepository
    {
        public BrandInfoRepository(IDbContextProvider<SalesSystemDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public List<BrandInfo> GetBrandInfosByBrandIds(int[] brandIds)
        {
            var brandInfoList = new List<BrandInfo>();
            foreach (int item in brandIds)
            {
                var brandInfo = this.Get(item);
                brandInfoList.Add(brandInfo);
            }
            return brandInfoList;
        }

        //public override BrandInfo Get(int id)
        //{
        //    var brandInfo = base.Get(id);
        //    var brandServiceInfoMapEventData  = new BrandServiceInfoMapEventData(brandInfo); 
        //    EventBus.Default.Trigger(brandServiceInfoMapEventData);
        //    brandInfo.ServiceInfos = brandServiceInfoMapEventData.ServiceInfos;
        //    return brandInfo;
        //}
    }
}
