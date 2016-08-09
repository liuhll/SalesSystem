﻿using System.Web.Mvc;

namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    public class HomeController : SalesSystemAdminControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}