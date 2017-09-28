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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            switch (model.PacketAction)
            {
                case PacketAction.Execute:
                    var packet = _dataMapper.Map<PacketViewModel, Packet>(model);
                    packet = _executor.Execute(packet);
                    model = _dataMapper.Map<Packet, PacketViewModel>(packet);
                    return View(model);
                case PacketAction.SaveInDb:
                    return RedirectToAction("SaveInDb");
                case PacketAction.LoadFromDb:
                    return RedirectToAction("LoadFromDb");
                case PacketAction.SaveInFile:
                    return RedirectToAction("SaveInFile");
                case PacketAction.LoadFromFile:
                    return RedirectToAction("LoadFromFile");
                default:
                    return null;
            }
        }

        public ActionResult SaveInDb()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult LoadFromDb()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult SaveInFile()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult LoadFromFile()
        {
            throw new System.NotImplementedException();
        }
    }
}