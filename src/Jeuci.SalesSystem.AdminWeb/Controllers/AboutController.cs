using System.Web.Mvc;

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