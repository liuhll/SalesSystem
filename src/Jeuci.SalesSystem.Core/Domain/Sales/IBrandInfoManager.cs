﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Domain.Sales
{
    public interface IBrandInfoManager : ITransientDependency
    {
        Task<IList<BrandInfo>> GetBrandsByCurrentUserBrandIds(string brandIds);
    }
}
