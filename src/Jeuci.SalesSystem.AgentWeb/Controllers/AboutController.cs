using System.Web.Mvc;

namespace Jeuci.SalesSystem.Web.Controllers
{
    public class AboutController : SalesSystemControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}