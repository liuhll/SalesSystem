using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Navigation;
using Abp.Localization;

namespace Jeuci.SalesSystem.AdminWeb
{
    public class SalesSystemAdminNavigationProvider : NavigationProvider
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