using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Castle.Core.Internal;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Brands.Dtos;
using Jeuci.SalesSystem.Domain.Sales;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;
using Jeuci.SalesSystem.Users;

namespace Jeuci.SalesSystem.Brands
{
    public class BrandAppService : CrudAppService<BrandInfo, BrandInfoDto>, IBrandAppService
    {
      //  private readonly IBrandInfoRepository _brandInfoRepository;
        private readonly IBrandInfoManager _brandInfoManager;
        public BrandAppService(IBrandInfoRepository repository, IBrandInfoManager brandInfoManager) : base(repository)
        {

            _brandInfoManager = brandInfoManager;
        }
 

        public async Task<IList<BrandInfoDto>> GetBrandsByCurrentUserBrandIds(string brandIds)
        {           
            var brandList = await _brandInfoManager.GetBrandsByCurrentUserBrandIds(brandIds);           
            return brandList.MapTo<IList<BrandInfoDto>>();
        }
    }
}
