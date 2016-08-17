using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Services.Dtos;

namespace Jeuci.SalesSystem.Services
{
    public interface IServicePriceAppService : ICrudAppService<ServicePriceDto>
    {
    }
}
