using Jeuci.SalesSystem.Users;
using System.Web.Mvc;
using Abp.Application.Services.Dto;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class HomeController : SalesSystemControllerBase
    {
        private readonly IUserInfoAppService _userInfoAppService;

        public HomeController(IUserInfoAppService userInfoAppService)
        {
            _userInfoAppService = userInfoAppService;
        }

        public ActionResult Index()
        {
            var test = _userInfoAppService.GetAll(new Application.Dtos.DefaultPagedResultRequest() { });
            var test2 = _userInfoAppService.Get(new IdInput() {Id = 1035});
            return View();
        }
	}
}