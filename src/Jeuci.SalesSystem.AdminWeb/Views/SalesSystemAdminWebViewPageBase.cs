using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Web.Mvc.Views;

namespace Jeuci.SalesSystem.AdminWeb.Views
{
    public abstract class SalesSystemAdminWebViewPageBase : SalesSystemAdminWebViewPageBase<dynamic>
    {
    }

    public abstract class SalesSystemAdminWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SalesSystemAdminWebViewPageBase()
        {
            LocalizationSourceName = SalesSystemConsts.LocalizationSourceName;
        }
    }
}