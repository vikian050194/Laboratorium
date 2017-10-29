﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;
using Laboratorium.DAL;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Laboratorium.Controllers
{
    [Authorize]
    public class ConsoleController : Controller
    {
        private readonly LaboratoriumContext _context;
        private readonly DataMapper _dataMapper;
        private readonly Executor _executor;
        private readonly int _pageSize = Properties.Settings.Default.PageSize;
        private readonly int _pagesSetSize = Properties.Settings.Default.PagesSetSize;

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
                var packetEntity = _context.Packets.Find(id);

                if (packetEntity != null)
                {
                    model  = _dataMapper.Map<PacketEntity, PacketViewModel>(packetEntity);
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
                case PacketAction.Save:
                    return RedirectToAction("LoadPacket");
                case PacketAction.Load:
                    return RedirectToAction("LoadPacket");
                case PacketAction.Delete:
                    return RedirectToAction("LoadPacket");
                default:
                    return null;
            }
        }

        [HttpGet]
        public ActionResult LoadPacket()
        {
            var model = new PacketsInViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult LoadFromDbPartial(PacketsInViewModel inputModel)
        {
            var titlePattern = inputModel.Filtering.Title ?? "";
            var codePattern = inputModel.Filtering.Script ?? "";
            var authorPattern = inputModel.Filtering.Author ?? "";
            var currentUserId = User.Identity.GetUserId();
            var scripts = _context
                .Packets
                .Where(s => 
                (s.IsPublic && inputModel.Filtering.IsPublic ||
                s.IsPublic == inputModel.Filtering.IsPublic && s.AspNetUserId == currentUserId) &&
                s.IsReusable == inputModel.Filtering.IsReusable &&
                s.Title.Contains(titlePattern) &&
                s.Script.Contains(codePattern) &&
                s.AspNetUser.LastName.Contains(authorPattern))
                .Include(s => s.AspNetUser);

            switch (inputModel.Sorting.OrderBy)
            {
                case "Title":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.Title) : scripts.OrderByDescending(s => s.Title);
                    break;
                case "Script":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.Script) : scripts.OrderByDescending(s => s.Script);
                    break;
                case "Author":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.AspNetUser.LastName) : scripts.OrderByDescending(s => s.AspNetUser.LastName);
                    break;
            }

            var currentPage = inputModel.IsFilterChanged ? 1 : inputModel.CurrentPage;

            var paging = new PagingManager().GetPaging(scripts.Count(), currentPage, _pageSize, _pagesSetSize);

            var page = scripts
                .Skip((currentPage - 1) * _pageSize)
                .Take(_pageSize);

            var list = _dataMapper.Map<List<PacketEntity>, List<PacketItem>>(page.ToList());

            var outputModel = new PacketsOutViewModel
            {
                Rows = list,
                Paging = paging
            };

            return Json(outputModel);
        }

        [HttpGet]
        public ActionResult ShowFullPacket(int id)
        {
            var packetEntity = _context.Packets.Include(s => s.AspNetUser).FirstOrDefault(s => s.Id == id);
            var model = _dataMapper.Map<PacketEntity, FullPacketViewModel>(packetEntity);

            return View(model);
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