using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeuci.SalesSystem.AdminWeb.Controllers;

namespace Jeuci.SalesSystem.AdminWeb.Areas.Sales.Controllers
{
    public class SalesSoftwareController : AuthorizeControllerBase
    {
        // GET: Sales/SalesSoftware
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Record()
        {
            return View();
        }
    }
}