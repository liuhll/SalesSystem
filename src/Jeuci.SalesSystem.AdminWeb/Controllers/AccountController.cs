using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Web.Mvc.Models;
using Microsoft.Owin.Security;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.AdminWeb.Models.Account;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Domain.Administrators;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Microsoft.AspNet.Identity;
using Abp.UI;

namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    public class AccountController : SalesSystemControllerBase
    {
        private readonly IAdministratorManager _userManager;

        private readonly IRepository<AgentInfo> _repository;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(AdministratorManager userManager, IRepository<AgentInfo> repository)
        {
            _userManager = userManager;
            _repository = repository;
            //  _userManager = userManager;
        }

        // GET: Account/Login?returnUrl="returnUrl"
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
        public async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "")
        {
            CheckModelState();

            
            var loginResult = await _userManager.LoginAsync(loginModel.Username,loginModel.Password);
            switch (loginResult.Result)
            {
                case LoginResultType.Success:
                    return SignInAsync(loginModel, ref returnUrl, loginResult);
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, loginModel.Username);
            }
       
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        private JsonResult SignInAsync(LoginViewModel loginModel, ref string returnUrl, UserManagerBase<AdministratorInfo>.LoginResult loginResult)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, loginResult.Identity);
            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
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
                default: //Can not fall to default actually. But other result InvalidPassword can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"), L("LoginFailedOther"));
            }
        }

        

    }
}