using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Domain.Sales.Impl
{
    public class BrandInfoManager : IBrandInfoManager
    {
        private readonly IBrandInfoRepository _brandInfoRepository;
        private readonly IServiceInfoRepository _serviceInfoRepository;
        private readonly IServicePriceRepository _servicePriceRepository;
        public BrandInfoManager(IBrandInfoRepository brandInfoRepository,
            IServiceInfoRepository serviceInfoRepository,
            IServicePriceRepository servicePriceRepository)
        {
            _brandInfoRepository = brandInfoRepository;
            _serviceInfoRepository = serviceInfoRepository;
            _servicePriceRepository = servicePriceRepository;
        }

        public async Task<IList<BrandInfo>> GetBrandsByCurrentUserBrandIds(string brandIds)
        {
            var brandStrIds = brandIds.Split(',').ToArray();
            var brandIntIds = Array.ConvertAll<string, int>(brandStrIds, s => int.Parse(s));

            var brandInfoList = _brandInfoRepository.GetBrandInfosByBrandIds(brandIntIds);
            return brandInfoList;
        }
    }
}
