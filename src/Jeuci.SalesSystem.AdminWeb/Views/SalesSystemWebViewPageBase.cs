using Abp.Web.Mvc.Views;

namespace Jeuci.SalesSystem.AdminWeb.Views
{
    public abstract class SalesSystemWebViewPageBase : SalesSystemWebViewPageBase<dynamic>
    {

    }

    public abstract class SalesSystemWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SalesSystemWebViewPageBase()
        {
            LocalizationSourceName = SalesSystemConsts.LocalizationSourceName;
        }
    }
}