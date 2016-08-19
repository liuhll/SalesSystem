using System.Collections.Generic;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.SoftServices.Dtos;

namespace Jeuci.SalesSystem.SoftServices
{
    public interface IServiceInfoAppService : ICrudAppService<ServiceInfoDto>
    {
        Task<IList<ServiceInfoDto>> GetAllServiceInfoList();
    }
}
