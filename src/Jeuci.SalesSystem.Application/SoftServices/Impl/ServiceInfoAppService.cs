using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
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

        public async Task<IList<ServiceInfoDto>> GetAllServiceInfoList()
        {
            var serviceInfoList = await Repository.GetAllListAsync();
            return serviceInfoList.MapTo<IList<ServiceInfoDto>>();
        }
    }
}
