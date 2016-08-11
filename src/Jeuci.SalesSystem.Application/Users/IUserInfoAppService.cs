using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Users
{
    public interface IUserInfoAppService : ICrudAppService<UserInfoDto>
    {
       

    }
}
