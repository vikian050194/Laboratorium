using System.Web.Mvc;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
		
		[HttpGet]
        public ActionResult About()
        {
            return View();
        }

		[HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
		
		[HttpGet]
        public ActionResult HowToUse()
        {
            return View();
        }
		
		[HttpGet]
        public ActionResult Examples()
        {
            return View();
        }
		
		[HttpGet]
        public ActionResult Books()
        {
            return View();
        }
    }
}