using System.Collections.Generic;
using Abp.Localization;

namespace Jeuci.SalesSystem.AdminWeb.Models.Layout
{
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}