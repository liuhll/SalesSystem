using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Jeuci.SalesSystem.AdminWeb.Controllers;
using Jeuci.SalesSystem.AdminWeb.Controllers.ControllerBases;
using Jeuci.SalesSystem.Application.Dtos;
using Jeuci.SalesSystem.Brands;
using Jeuci.SalesSystem.Repositories;
using Jeuci.SalesSystem.Sales.Dtos;
using Jeuci.SalesSystem.SoftServices;

namespace Jeuci.SalesSystem.AdminWeb.Areas.Sales.Controllers
{
    public class SalesSoftwareController : AuthorizeControllerBase
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IServiceInfoAppService _serviceInfoAppService;
        public SalesSoftwareController(IBrandAppService brandAppService,
            IServiceInfoAppService serviceInfoAppService)
        {
            _brandAppService = brandAppService;
            _serviceInfoAppService = serviceInfoAppService;
        }

        // GET: Sales/SalesSoftware
        public async Task<ActionResult> Index()
        {
            var currentUserBrandList = await _brandAppService.GetBrandsByCurrentUserBrandIds(CurrentUserInfo.Brands);
            return View(currentUserBrandList);
        }
    
        public ActionResult SalesService(int id)
        {
            var serviceInfo = _serviceInfoAppService.Get(new IdInput() {Id = id});
            return PartialView("_SalesService", serviceInfo);
        }

        [HttpPost]
        public ActionResult SalesService(SalesInput model)
        {
            var test = model;
            return null;
        }

        public ActionResult Record()
        {
            return View();
        }

    }
}