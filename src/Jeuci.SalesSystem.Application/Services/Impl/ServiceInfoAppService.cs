using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Brands;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Services.Dtos;

namespace Jeuci.SalesSystem.Services.Impl
{
    public class ServiceInfoAppService : CrudAppService<ServiceInfo, ServiceInfoDto>, IServiceInfoAppService
    {
        public ServiceInfoAppService(IRepository<ServiceInfo, int> repository) : base(repository)
        {
        }
    }
}
