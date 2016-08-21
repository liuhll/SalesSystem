using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.WebApi.Controllers;
using System.Web.Http;
using Abp.UI;
using Abp.Web.Models;
using Jeuci.SalesSystem.Api.Models;
using Jeuci.SalesSystem.Domain.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Jeuci.SalesSystem.Api.Controllers
{
    
    public class AccountController : AbpApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly IAdministratorManager _userManager;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        public AccountController(IAdministratorManager userManager)
        {
            _userManager = userManager;
        }

 


        [HttpPost]
        public async Task<AjaxResponse> Authenticate(LoginViewModel loginModel)
        {
            CheckModelState();

            var loginResult = await _userManager.LoginAsync(loginModel.Username, loginModel.Password);

            var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());

            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

            return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        }

       
        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Invalid request!");
            }
        }
    }
}
