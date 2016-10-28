using System.Web.Mvc;
using AutoMapper;
using Laboratorium.Models.ViewModels;
using Laboratorium.Core;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        DataMapper _mapper = new DataMapper();

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

            var packet = _mapper.Map<PacketViewModel, Packet>(packetViewModel);

            packet = executor.Execute(packet);

            packetViewModel = _mapper.Map<Packet, PacketViewModel>(packet);

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