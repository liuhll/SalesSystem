using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Domain.Users
{
    public interface IUserManager
    {
    //    Task<UserManager.LoginResult> LoginAsync(string usernameOrEmailAddress, string password);
    //    Task<ClaimsIdentity> CreateIdentityAsync(UserInfo user, string applicationCookie);

        UserInfo TestMethod();
    }
}
