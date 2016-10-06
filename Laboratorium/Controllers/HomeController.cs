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
            return View();
        }

        [HttpGet]
        public ActionResult HandlePackage()
        {
            return PartialView(new PacketViewModel());
        }

        [HttpPost]
        public ActionResult HandlePackage(PacketViewModel packetViewModel)
        {
            var executor = new Executor();
            packetViewModel = executor.Execute(packetViewModel);
            return PartialView(packetViewModel);
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