using System.Web.Mvc;
using Laboratorium.Models.ViewModels;
using Laboratorium.Core;
using Laboratorium.Core.Managers;
using Laboratorium.Data;

namespace Laboratorium.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly DataMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly Executor _executor;

        public ConsoleController(IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = new DataMapper();
            _executor = new Executor(new RealPathManager());
        }

        [HttpGet]
        public ActionResult SimpleConsoleIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SimpleConsole()
        {
            return PartialView(new Packet());
        }

        [HttpPost]
        public ActionResult SimpleConsole(Packet packet)
        {
            packet = _executor.Execute(packet, false);

            return PartialView(packet);
        }

        [HttpGet]
        public ActionResult ComplexConsoleIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ComplexConsole()
        {
            var packet = _executor.GetNewEmptyPacket();
            return PartialView(packet);
        }

        [HttpPost]
        public ActionResult ComplexConsole(Packet packet)
        {
            packet = _executor.Execute(packet, true);

            return PartialView(packet);
        }
    }
}