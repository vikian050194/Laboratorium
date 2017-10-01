using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;
using Laboratorium.DAL;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Controllers
{
    [Authorize]
    public class ConsoleController : Controller
    {
        private readonly LaboratoriumContext _context;
        private readonly DataMapper _dataMapper;
        private readonly Executor _executor;

        public ConsoleController()
        {
            _dataMapper = new DataMapper();
            _executor = new Executor(new RealPathManager());
            _context = new LaboratoriumContext();
        }

        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            var packet = _executor.GetNewEmptyPacket();
            var model = _dataMapper.Map<Packet, PacketViewModel>(packet);

            if (id != 0)
            {
                var script = _context.Scripts.Find(id);

                if (script != null)
                {
                    model.Script = script.Code;
                }
            }

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
            return View();
        }

        [HttpGet]
        public ActionResult LoadFromDb()
        {
            var scripts = _context.Scripts.Where(s => !s.IsPrivate).ToList();
            var scriptsViewModel = _dataMapper.Map<List<Script>, List<ScriptViewModel>>(scripts);

            return View(scriptsViewModel);
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