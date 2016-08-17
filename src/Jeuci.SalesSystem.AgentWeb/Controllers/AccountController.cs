using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Web.Mvc.Models;
using Jeuci.SalesSystem.Application.Services;
using Microsoft.Owin.Security;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Entities.User;
using Jeuci.SalesSystem.Web.Models.Account;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class AccountController : SalesSystemControllerBase
    {
        //  private readonly IUserInfoManager _userManager;

        private readonly ICrudAppService<AgentInfo> _crudAppService;
        private readonly IRepository<AgentInfo> _repository;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(ICrudAppService<AgentInfo> crudAppService, IRepository<AgentInfo> repository)
        {
            _crudAppService = crudAppService;
            _repository = repository;
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