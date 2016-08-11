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
using Microsoft.AspNet.Identity;

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
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = loginModel.RememberMe }, loginResult.Identity);
            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

    }
}