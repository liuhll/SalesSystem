using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Models;
using Microsoft.Owin.Security;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Web.Models.Account;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class AccountController : SalesSystemControllerBase
    {
        private readonly IUserInfoManager _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserInfoManager userManager)
        {
            _userManager = userManager;
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
        public JsonResult Login(LoginViewModel loginModel, string returnUrl = "")
        {
            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }
    }
}