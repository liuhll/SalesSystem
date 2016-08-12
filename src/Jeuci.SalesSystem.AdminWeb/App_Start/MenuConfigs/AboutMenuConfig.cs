using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Navigation;
using Abp.Localization;

namespace Jeuci.SalesSystem.AdminWeb
{
    public static class AboutMenuConfig
    {
        public static MenuItemDefinition AddAboutMenuItems()
        {
            return new MenuItemDefinition(
                "About",
                new LocalizableString("About", SalesSystemConsts.LocalizationSourceName),
                url: "About",
                icon: "fa fa-info"
                );
        }
    }
}