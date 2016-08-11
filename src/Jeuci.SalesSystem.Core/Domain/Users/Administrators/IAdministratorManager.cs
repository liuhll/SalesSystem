using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities;
using Microsoft.AspNet.Identity;

namespace Jeuci.SalesSystem.Domain.Administrators
{
    public interface IAdministratorManager: IUserManagerBase<AdministratorInfo>   
    {
     
    }
}
