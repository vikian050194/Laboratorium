using System.Web.Mvc;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;
using Laboratorium.Helpers;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Controllers
{
    [Authorize]
    public class ConsoleController : Controller
    {
        private readonly DataMapper _dataMapper;
        private readonly Executor _executor;

        public ConsoleController()
        {
            _dataMapper = new DataMapper();
            _executor = new Executor(new RealPathManager());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var packet = _executor.GetNewEmptyPacket();
            var model = _dataMapper.Map<Packet, PacketViewModel>(packet);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PacketViewModel model)
        {
            var packet = _dataMapper.Map<PacketViewModel, Packet>(model);
            packet = _executor.Execute(packet);
            model = _dataMapper.Map<Packet, PacketViewModel>(packet);
            return View(model);
        }

        public ActionResult SaveFile()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult LoadFile()
        {
            throw new System.NotImplementedException();
        }
    }
}