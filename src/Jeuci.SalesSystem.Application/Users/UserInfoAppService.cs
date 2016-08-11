using Jeuci.SalesSystem.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Users
{
    public class UserInfoAppService : CrudAppService<UserInfo, UserInfoDto>, IUserInfoAppService
    {
        public UserInfoAppService(IRepository<UserInfo, int> repository) : base(repository)
        {
        }
    }
}
