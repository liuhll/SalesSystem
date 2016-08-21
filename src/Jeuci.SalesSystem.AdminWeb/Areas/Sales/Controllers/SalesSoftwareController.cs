using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.UI;
using Jeuci.SalesSystem.AdminWeb.Controllers.ControllerBases;
using Jeuci.SalesSystem.Brands;
using Jeuci.SalesSystem.Brands.Dtos;
using Jeuci.SalesSystem.Entities.Common.Enums;
using Jeuci.SalesSystem.Sales;
using Jeuci.SalesSystem.Sales.Dtos;
using Jeuci.SalesSystem.SoftServices;
using Jeuci.SalesSystem.SoftServices.Dtos;

namespace Jeuci.SalesSystem.AdminWeb.Areas.Sales.Controllers
{
    public class SalesSoftwareController : AuthorizeControllerBase
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IServiceInfoAppService _serviceInfoAppService;
        private readonly ISaleSoftwareAppService _saleSoftwareAppService;

        public SalesSoftwareController(IBrandAppService brandAppService,
            IServiceInfoAppService serviceInfoAppService, ISaleSoftwareAppService saleSoftwareAppService)
        {
            _brandAppService = brandAppService;
            _serviceInfoAppService = serviceInfoAppService;
            _saleSoftwareAppService = saleSoftwareAppService;
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
        public async Task<JsonResult> SalesService(SalesInput model)
        {
          //  CheckModelState();

            var result = await _saleSoftwareAppService.SalesSoftwareService(model,CurrentUserInfo.Id);
            switch (result.SalesResultType)
            {
                case SalesResultType.Success:
                    return Json(result);
                default:
                    throw  new UserFriendlyException("授权失败", result.Message);
            }
        }

        public async Task<ActionResult> Record()
        {
            var brandList = await _brandAppService.GetBrandsByCurrentUserBrandIds(CurrentUserInfo.Brands);
            brandList.Add(new BrandInfoDto()
            {
                Id = -1,
                BrandName = "所有品牌"
            });

            ViewBag.BrandList = brandList.OrderBy(p=>p.Id).Select(a => new SelectListItem()
            {
                Text = a.BrandName,
                Value = a.Id.ToString(),
                Selected = a.Id ==-1
            });

            var serviceInfoList = await _serviceInfoAppService.GetAllServiceInfoList();
            serviceInfoList.Add(new ServiceInfoDto()
            {
                Id = -1,
                BrandId = -1,
                ServiceName = "所有产品"

            });
            ViewBag.ServiceInfoList = serviceInfoList.OrderBy(p => p.Id).Select(a => new SelectListItem()
            {
                Text = a.ServiceName,
                Value = a.Id.ToString(),
                Selected = a.Id == -1
            });
            
            return View();
        }

    }
}