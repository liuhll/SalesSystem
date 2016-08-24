using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Abp.WebApi.Authorization;

namespace Jeuci.SalesSystem.Web
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