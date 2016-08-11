using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Jeuci.SalesSystem.Domain.Users.UserStore;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Microsoft.AspNet.Identity;
using Abp.Extensions;
using Jeuci.SalesSystem.Helper;

namespace Jeuci.SalesSystem.Domain.Users
{
    public class UserManagerBase<TUser> : UserManager<TUser,int>, IUserManagerBase<TUser> 
        where  TUser : UserBase
    {
        private readonly IRepository<TUser> _userRepository;
        private readonly IJueciUserStoreBase<TUser> _userStore;


        public UserManagerBase(IRepository<TUser> userRepository, IJueciUserStoreBase<TUser> userStore)
            : base(userStore)

        {
            _userRepository = userRepository;
            _userStore = userStore;
        }

        
        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            var result = await LoginAsyncInternal(username, password);
            // await SaveLoginAttempt(result, tenancyName, login.ProviderKey + "@" + login.LoginProvider);
            return result;
        }

        private async Task<LoginResult> LoginAsyncInternal(string userName, string plainPassword)
        {
            if (userName.IsNullOrEmpty())
            {
                throw new ArgumentNullException("userName");
            }

            if (plainPassword.IsNullOrEmpty())
            {
                throw new ArgumentNullException("plainPassword");
            }

            // :todo 第三方登录 ，估计不需要 
            var loggedInFromExternalSource = await TryLoginFromExternalAuthenticationSources(userName, plainPassword);

            var user = await _userRepository.FirstOrDefaultAsync(p => p.UserName == userName);
            if (user == null)
            {
                return new LoginResult(LoginResultType.InvalidUserName);
            }

            if (!user.IsActive)
            {
                return new LoginResult(LoginResultType.UserIsNotActive);
            }
            if (!loggedInFromExternalSource)
            {

                if (!Hash256Helper.GetUserSignByHash256(userName, user.Password).Equals(plainPassword))
                {
                    return new LoginResult(LoginResultType.InvalidPassword, user);
                }
            }

            return await CreateLoginResultAsync(user);
        }

        private async Task<LoginResult> CreateLoginResultAsync(TUser user)
        {
            if (!user.IsActive)
            {
                return new LoginResult(LoginResultType.UserIsNotActive);
            }
            return new LoginResult(user, await CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));
        }

        private async Task<bool> TryLoginFromExternalAuthenticationSources(string userName, string plainPassword)
        {
            // :TODO Try Login Form External AuthenticationSources，This Feature is not needed now
            return false;
        }

        public class LoginResult
        {
            public LoginResultType Result { get; private set; }


            public TUser User { get; private set; }

            public ClaimsIdentity Identity { get; private set; }

            public LoginResult(LoginResultType result, TUser user = null)
            {
                this.Result = result;
                this.User = user;
            }

            public LoginResult(TUser user, ClaimsIdentity identity)
              : this(LoginResultType.Success, default(TUser))
            {
                this.User = user;
                this.Identity = identity;
            }
        }

       
    }
}
