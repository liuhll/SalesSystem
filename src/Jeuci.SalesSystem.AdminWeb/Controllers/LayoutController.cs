using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Threading;
using Jeuci.SalesSystem.AdminWeb.Controllers.ControllerBases;
using Jeuci.SalesSystem.AdminWeb.Models.Layout;

namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    public class LayoutController : AuthorizeControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;

        public LayoutController(IUserNavigationManager userNavigationManager, ILocalizationManager localizationManager)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
        }

        [ChildActionOnly]
        public PartialViewResult SideMenu(string activeMenu = "")
        {
            var model = new TopMenuViewModel
                        {
                            MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId)),
                            ActiveMenuItemName = activeMenu
                        }; 

            return PartialView("_SideMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
                        {
                            CurrentLanguage = _localizationManager.CurrentLanguage,
                            Languages = _localizationManager.GetAllLanguages()
                        };

            return PartialView("_LanguageSelection", model);
        }
    }
}