using System.Net.Http.Headers;
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
        //    config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.Filters.Add(new AbpApiAuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();


        }
    }
}