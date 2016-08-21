using System.Web.Http;
using Abp.Web.Mvc.Authorization;
using Abp.WebApi.Authorization;
using Microsoft.Owin.Security.OAuth;

namespace Jeuci.SalesSystem.AdminWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.Filters.Add(new AbpApiAuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();


        }
    }
}