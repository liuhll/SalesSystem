using System.Web.Mvc;
using Jeuci.SalesSystem.AdminWeb.Controllers.ControllerBases;

namespace Jeuci.SalesSystem.AdminWeb.Controllers
{
    public class AboutController : AuthorizeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}