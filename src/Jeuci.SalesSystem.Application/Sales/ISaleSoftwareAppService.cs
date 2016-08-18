using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common;
using Jeuci.SalesSystem.Sales.Dtos;

namespace Jeuci.SalesSystem.Sales
{
    public interface ISaleSoftwareAppService : ITransientDependency
    {
        Task<SalesResultMessage> SalesSoftwareService(SalesInput model, int salesManId);
    }
}

