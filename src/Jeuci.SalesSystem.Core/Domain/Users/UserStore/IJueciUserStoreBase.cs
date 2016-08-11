using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Jeuci.SalesSystem.Entities;
using Microsoft.AspNet.Identity;

namespace Jeuci.SalesSystem.Domain.Users.UserStore
{
    public interface IJueciUserStoreBase<TUser> : ITransientDependency , IUserStore<TUser,int> where TUser :  class,  IUser<int>
    {
    }
}
