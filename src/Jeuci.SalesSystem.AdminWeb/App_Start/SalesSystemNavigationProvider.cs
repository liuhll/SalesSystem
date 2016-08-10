using System.Security.Policy;
using Abp.Application.Navigation;
using Abp.Localization;

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
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SalesSystemConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-legal"
                        ).AddItem(
                           new MenuItemDefinition(
                                "SaleSoftware",
                                new LocalizableString("NavBar_SaleSoftware", SalesSystemConsts.LocalizationSourceName),
                                url: "SaleSoftware/Index",
                                icon: "fa fa-legal"
                               )
                        ).AddItem(
                          new MenuItemDefinition(
                                "SaleSoftwareRecord",
                                new LocalizableString("NavBar_SaleSoftwareRecord", SalesSystemConsts.LocalizationSourceName),
                                url: "SaleSoftware/Record",
                                icon: "fa fa-list-alt"
                            )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", SalesSystemConsts.LocalizationSourceName),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}
