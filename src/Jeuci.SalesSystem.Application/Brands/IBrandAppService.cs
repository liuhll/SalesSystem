using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Brands.Dtos;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Brands
{
    public interface IBrandAppService :ICrudAppService<BrandInfoDto>
    {
       Task<IList<BrandInfoDto>> GetBrandsByCurrentUserBrandIds(string brandIds);

    }
}
