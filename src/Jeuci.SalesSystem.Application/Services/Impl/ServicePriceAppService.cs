using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Services.Dtos;

namespace Jeuci.SalesSystem.Services.Impl
{
    public class ServicePriceAppService : CrudAppService<ServicePrice, ServicePriceDto>, IServicePriceAppService
    {
        public ServicePriceAppService(IRepository<ServicePrice, int> repository) : base(repository)
        {
        }
    }
}