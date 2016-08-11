using Abp.UI;
using Abp.Web.Mvc.Controllers;

namespace Jeuci.SalesSystem.AdminWeb.Controllers
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

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }
    }
}