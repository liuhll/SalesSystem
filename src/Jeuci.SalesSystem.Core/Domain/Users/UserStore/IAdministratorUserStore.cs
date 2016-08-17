using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;

namespace Jeuci.SalesSystem.Domain.Users.UserStore
{
    public interface IAdministratorUserStore : IJueciUserStoreBase<AdministratorInfo> 
    {
    }
}
