using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Abp.WebApi.Authorization;

namespace Jeuci.SalesSystem.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {         
            filters.Add(new AbpMvcAuthorizeAttribute());
        }
    }
}
