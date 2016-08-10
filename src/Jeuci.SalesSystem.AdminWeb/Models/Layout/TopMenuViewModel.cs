using Abp.Application.Navigation;

namespace Jeuci.SalesSystem.AdminWeb.Models.Layout
{
    public class TopMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}