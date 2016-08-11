using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Repositories.Interface;
using System.Security.Claims;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Abp.Extensions;
using Jeuci.SalesSystem.Configuration;
using Abp.Timing;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Domain.Users.UserStore;
using Microsoft.AspNet.Identity;


namespace Jeuci.SalesSystem.Domain.Administrators
{
    public class AdministratorManager : UserManagerBase<AdministratorInfo>, IAdministratorManager

    {
        private readonly IAdministratorInfoRepository _administratorInfoRepository;
        private readonly IAdministratorUserStore _adminUserStore;
       

        public AdministratorManager(IAdministratorInfoRepository userRepository, IAdministratorUserStore adminUserStore)
            : base(userRepository, adminUserStore)
        {
            _administratorInfoRepository = userRepository;
            _adminUserStore = adminUserStore;
        }
    }
}
