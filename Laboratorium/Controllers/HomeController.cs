using System.IO;
using System.Linq;
using System.Web.Mvc;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PacketViewModel());
        }

        [HttpPost]
        public ActionResult Index(PacketViewModel packetViewModel)
        {
            var executor = new Executor();
            packetViewModel = executor.Execute(packetViewModel);
            return View("Index", packetViewModel);
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