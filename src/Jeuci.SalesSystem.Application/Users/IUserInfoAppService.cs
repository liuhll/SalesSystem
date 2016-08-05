using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Users
{
    public interface IUserInfoAppService : ICrudAppService<UserInfoDto>
    {
    }
}
