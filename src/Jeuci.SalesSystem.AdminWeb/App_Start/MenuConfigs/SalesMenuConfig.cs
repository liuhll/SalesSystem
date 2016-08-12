using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jeuci.SalesSystem.AdminWeb
{
    public static class SalesMenuConfig
    {
        public static MenuItemDefinition AddSalesMenuItems()
        {
            return new MenuItemDefinition(
                                    "Sale",
                                    new LocalizableString("HomePage", SalesSystemConsts.LocalizationSourceName),
                                    url: "",
                                    icon: "fa fa-legal"
                                    ).AddItem(
                                       new MenuItemDefinition(
                                            "SaleSoftware",
                                            new LocalizableString("NavBar_SaleSoftware", SalesSystemConsts.LocalizationSourceName),
                                            url: "Sales/SalesSoftware/Index",
                                            icon: "fa fa-legal"
                                           )
                                    ).AddItem(
                                      new MenuItemDefinition(
                                            "SaleSoftwareRecord",
                                            new LocalizableString("NavBar_SaleSoftwareRecord", SalesSystemConsts.LocalizationSourceName),
                                            url: "Sales/SalesSoftware/Record",
                                            icon: "fa fa-list-alt"
                                        )
                                    );
        }
    }
}