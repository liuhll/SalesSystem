using Jeuci.SalesSystem.Users;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Web.Mvc.Authorization;
using Jeuci.SalesSystem.Agents;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Application.Services;
using Jeuci.SalesSystem.Domain.Users;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Web.Controllers
{
  //  [AbpMvcAuthorize]
    public class HomeController : SalesSystemControllerBase
    {
        private readonly IUserInfoAppService _userInfoAppService;

        private readonly IAgentInfoAppService _agentInfoAppService;
    
        public HomeController(IUserInfoAppService userInfoAppService,IAgentInfoAppService agentInfoAppService)
        {
            _userInfoAppService = userInfoAppService;
            _agentInfoAppService = agentInfoAppService;
        }

        public ActionResult Index()
        {
            var test = _userInfoAppService.GetAll(new Application.Dtos.DefaultPagedResultRequest() { });
            var test2 = _userInfoAppService.Get(new IdInput() { Id = 1035 });


            var agentUsers = _agentInfoAppService.GetAll(new DefaultPagedResultRequest() {});

            return View();
        }
	}
}