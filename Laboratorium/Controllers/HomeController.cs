using System.Web.Mvc;
using Laboratorium.Models.ViewModels;
using LaboratoriumCore;

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
        public ActionResult PackageForm()
        {
            return PartialView(new PacketViewModel());
        }

        [HttpPost]
        public ActionResult PackageForm(PacketViewModel packetViewModel)
        {
            var executor = new Executor(new ExecutorHelper());

            var packet = new Packet
            {
                Errors = packetViewModel.Errors,
                Results = packetViewModel.Results,
                Query = packetViewModel.Query
            };
            packet = executor.Execute(packet);

            packetViewModel.Query = packet.Query;
            packetViewModel.Errors = packet.Errors;
            packetViewModel.Results = packet.Results;

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