using System.Security.Policy;
using Abp.Application.Navigation;
using Abp.Localization;
using Jeuci.SalesSystem.AdminWeb.MenuConfigs;

namespace Jeuci.SalesSystem.AdminWeb
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class SalesSystemNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {

            var mainMenu = context.Manager.MainMenu;
            mainMenu.AddItem(SalesMenuConfig.AddSalesMenuItems());          
            mainMenu.AddItem(ProductMenuConfig.AddProductMenuItems());

            mainMenu.AddItem(AboutMenuConfig.AddAboutMenuItems());

        }

        
    }


}
