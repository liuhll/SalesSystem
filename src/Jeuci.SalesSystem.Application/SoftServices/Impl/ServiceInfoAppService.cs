using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.SoftServices.Dtos;

namespace Jeuci.SalesSystem.SoftServices.Impl
{
    public class ServiceInfoAppService : CrudAppService<ServiceInfo, ServiceInfoDto>, IServiceInfoAppService
    {
        public ServiceInfoAppService(IRepository<ServiceInfo, int> repository) : base(repository)
        {
        }
    }
}
