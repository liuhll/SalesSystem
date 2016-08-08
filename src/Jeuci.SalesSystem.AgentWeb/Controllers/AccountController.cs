using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.UI;
using Abp.Web.Models;
using Abp.Web.Mvc.Models;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Web.Models.Account;
using Jeuci.SalesSystem.Entities.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class AccountController : SalesSystemControllerBase
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly IUserManager _userManager;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: Account/Login
        public ActionResult Login(string returnUrl = "")
        {
            var test = _userManager.TestMethod();
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }
            return View(
                new LoginFormViewModel
                {
                    ReturnUrl = returnUrl,                   
                });
        }

        [HttpPost]
        [DisableAuditing]
        public async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            CheckModelState();

            var loginResult = await GetLoginResultAsync(
                loginModel.UsernameOrEmailAddress,
                loginModel.Password
                );

            await SignInAsync(loginResult.User, loginResult.Identity, loginModel.RememberMe);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }

        private async Task SignInAsync(UserInfo user, ClaimsIdentity identity, bool rememberMe)
        {
            if (identity == null)
            {
              //  identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);
        }

        private async Task<UserManager.LoginResult> GetLoginResultAsync(string usernameOrEmailAddress, string password)
        {
         //   var loginResult = await _userManager.LoginAsync(usernameOrEmailAddress, password);

            //switch (loginResult.Result)
            //{
            //    case LoginResultType.Success:
            //        return loginResult;
            //    default:
            //        throw CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress);
            //}
            return null;
        }

        private Exception CreateExceptionForFailedLoginAttempt(LoginResultType result, string usernameOrEmailAddress)
        {
            switch (result)
            {
                case LoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case LoginResultType.InvalidUserNameOrEmailAddress:
                case LoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case LoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case LoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            
        }

    }
}
}