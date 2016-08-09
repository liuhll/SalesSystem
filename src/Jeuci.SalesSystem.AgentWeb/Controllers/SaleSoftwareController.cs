using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class SaleSoftwareController : SalesSystemControllerBase
    {
        // GET: SaleSoftware
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