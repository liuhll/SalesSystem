using Abp.Web.Mvc.Controllers;

namespace Jeuci.SalesSystem.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class SalesSystemControllerBase : AbpController
    {
        protected SalesSystemControllerBase()
        {
            LocalizationSourceName = SalesSystemConsts.LocalizationSourceName;
        }
    }
}