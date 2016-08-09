using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Enum;

namespace Jeuci.SalesSystem.Domain.Users
{
    public class UserManager : IUserManager
    {
        [UnitOfWork]
        public async Task<LoginResult> LoginAsync(string usernameOrEmailAddress, string password)
        {
            UserManager.LoginResult result = await this.LoginAsyncInternal(usernameOrEmailAddress, password);
            await this.SaveLoginAttempt(result, usernameOrEmailAddress);
            return result;
        }

        private async Task SaveLoginAttempt(UserManager.LoginResult result, string userNameOrEmailAddress)
        {
            throw new NotImplementedException();
        }

        private async Task<LoginResult> LoginAsyncInternal(string userNameOrEmailAddress, string plainPassword)
        {
            //if (login == null || login.LoginProvider.IsNullOrEmpty() || login.ProviderKey.IsNullOrEmpty())
            //    throw new ArgumentException("login");
            //TTenant tenant = default(TTenant);
            //if (!this._multiTenancyConfig.IsEnabled)
            //    tenant = await this.GetDefaultTenantAsync();
            //else if (!string.IsNullOrWhiteSpace(tenancyName))
            //{
            //    tenant = await this._tenantRepository.FirstOrDefaultAsync((Expression<Func<TTenant, bool>>)(t => t.TenancyName == tenancyName));
            //    if ((Entity<int>)tenant == (Entity<int>)null)
            //        return new AbpUserManager<TTenant, TRole, TUser>.AbpLoginResult(AbpLoginResultType.InvalidTenancyName, default(TTenant), default(TUser));
            //    if (!tenant.IsActive)
            //        return new AbpUserManager<TTenant, TRole, TUser>.AbpLoginResult(AbpLoginResultType.TenantIsNotActive, tenant, default(TUser));
            //}
            //int? tenantId = (Entity<int>)tenant == (Entity<int>)null ? new int?() : new int?(tenant.Id);
            //using (this._unitOfWorkManager.Current.SetTenantId(tenantId))
            //{
            //    TUser async = await this.AbpStore.FindAsync(tenantId, login);
            //    if ((Entity<long>)async == (Entity<long>)null)
            //        return new AbpUserManager<TTenant, TRole, TUser>.AbpLoginResult(AbpLoginResultType.UnknownExternalLogin, tenant, default(TUser));
            //    return await this.CreateLoginResultAsync(async, tenant);
            //}
            throw new NotImplementedException();
        }

        
        //async Task<UserManager.LoginResult> IUserManager.LoginAsync(string userNameOrEmailAddress, string plainPassword)
        //{
        //    UserManager.LoginResult result = await this.LoginAsyncInternal(userNameOrEmailAddress, plainPassword);
        //    await this.SaveLoginAttempt(result, userNameOrEmailAddress);
        //    return result;
        //}

        public Task<ClaimsIdentity> CreateIdentityAsync(UserInfo user, string applicationCookie)
        {
            throw new NotImplementedException();
        }

        public class LoginResult
        {
            public LoginResultType Result { get; private set; }

            public UserInfo User { get; private set; }

            public ClaimsIdentity Identity { get; private set; }

            public LoginResult(LoginResultType result, UserInfo user = null)
            {
                this.Result = result;
                this.User = user;
            }

            public LoginResult(UserInfo user, ClaimsIdentity identity)
              : this(LoginResultType.Success, default(UserInfo))
            {
                this.User = user;
                this.Identity = identity;
            }
        }

        public UserInfo TestMethod()
        {
            return new UserInfo() {Id = 1};
        }
    }
}
