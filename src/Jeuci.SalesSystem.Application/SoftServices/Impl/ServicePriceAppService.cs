using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.SoftServices.Dtos;

namespace Jeuci.SalesSystem.SoftServices.Impl
{
    public class ServicePriceAppService : CrudAppService<ServicePrice, ServicePriceDto>, IServicePriceAppService
    {
        public ServicePriceAppService(IRepository<ServicePrice, int> repository) : base(repository)
        {
        }
    }
}