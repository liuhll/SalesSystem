using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;


namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    [AbpMvcAuthorize]
    public class AuthorizeControllerBase : SalesSystemControllerBase
    {

    }
}