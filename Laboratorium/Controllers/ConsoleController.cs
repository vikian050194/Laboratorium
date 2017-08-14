﻿using System.Web.Mvc;
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
            return View();
        }

        [HttpGet]
        public ActionResult Console()
        {
            var packet = _executor.GetNewEmptyPacket();
            var model = _dataMapper.Map<Packet, PacketViewModel>(packet);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Console(PacketViewModel model)
        {
            var packet = _dataMapper.Map<PacketViewModel, Packet>(model);

            switch (model.Action)
            {
                case PacketAction.Execute:
                    packet = _executor.Execute(packet);
                    if (packet.IsError)
                    {
                        return PartialView(model);
                    }
                    break;
            }

            return RedirectToAction("Index");
        }
    }
}