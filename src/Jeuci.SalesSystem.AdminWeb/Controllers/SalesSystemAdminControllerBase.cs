using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Modules;
using Abp.UI;
using Abp.Web.Mvc.Controllers;


namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    public class SalesSystemAdminControllerBase : AbpController
    {
        protected SalesSystemAdminControllerBase()
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