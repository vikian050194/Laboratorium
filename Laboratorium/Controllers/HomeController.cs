using System.Web.Mvc;
using Laboratorium.Models.ViewModels;
using Laboratorium.Core;
using Laboratorium.Data;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataMapper _mapper;
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;

            _mapper = new DataMapper();
        }

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
            var executor = new Executor();

            var packet = _mapper.Map<PacketViewModel, Packet>(packetViewModel);
            packet.User = "foo@bar.com";
            //packet.User = User.Identity.Name;

            packet = executor.Execute(packet);

            var newPacketViewModel = _mapper.Map<Packet, PacketViewModel>(packet);
            newPacketViewModel.ShowEntireScript = packetViewModel.ShowEntireScript;

            return PartialView(newPacketViewModel);
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