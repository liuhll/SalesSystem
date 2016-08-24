using Jeuci.SalesSystem.Domain.Users.UserStore;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Repositories.Interface;

namespace Jeuci.SalesSystem.Domain.Users.Administrators
{
    public class AdministratorManager : UserManagerBase<AdministratorInfo>, IAdministratorManager

    {
        private readonly IAdministratorInfoRepository _administratorInfoRepository;
        private readonly IAdministratorUserStore _adminUserStore;
       

        public AdministratorManager(IAdministratorInfoRepository userRepository, IAdministratorUserStore adminUserStore)
            : base(userRepository, adminUserStore,UserRole.Admin)
        {
            _administratorInfoRepository = userRepository;
            _adminUserStore = adminUserStore;
        }
    }
}
