using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Mvc.Models;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Configuration;
using Microsoft.Owin.Security;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Domain.Users.Agents;
using Jeuci.SalesSystem.Domain.Users.Authorization;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Entities.User;
using Jeuci.SalesSystem.Web.Models.Account;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class AccountController : SalesSystemControllerBase
    {
        private readonly IAgentManager _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IAgentManager userManager)
        {
            _userManager = userManager;
        }

        // GET: Account/Login?returnUrl="returnUrl"
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            return View(
                new LoginFormViewModel
                {
                    ReturnUrl = returnUrl
                });
        }

        [HttpPost]
        [DisableAuditing]
        [AllowAnonymous]
        public async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "")
        {
            CheckModelState();

            var loginResult = await _userManager.LoginAsync(loginModel.Username, loginModel.Password);
            switch (loginResult.Result)
            {
                case LoginResultType.Success:
                    return SignInAsync(loginModel, ref returnUrl, loginResult);
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, loginModel.Username);
            }
        }

        private Exception CreateExceptionForFailedLoginAttempt(LoginResultType result, string username)
        {
            switch (result)
            {
                case LoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case LoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActive"));
                case LoginResultType.InvalidUserName:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserName", username));
                case LoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidPassword"));
                case LoginResultType.NotAgentUser:
                    return new UserFriendlyException(L("LoginFailed"), L("NotAgentUser"));

                default: //Can not fall to default actually. But other result InvalidPassword can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"), L("LoginFailedOther"));
            }
        }

        private JsonResult SignInAsync(LoginViewModel loginModel, ref string returnUrl, UserManagerBase<UserInfo>.LoginResult loginResult)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }
            Session.Add(SalesSystemConsts.CurrentAgentSessionName, loginResult.User);
            AuthenticationManager.SignOut(JueciAuthenticationTypes.ApplicationAgentCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, loginResult.Identity);
            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }
    }
}