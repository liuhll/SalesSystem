using Abp.Application.Navigation;
using Abp.Localization;

namespace Jeuci.SalesSystem.AdminWeb.MenuConfigs
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