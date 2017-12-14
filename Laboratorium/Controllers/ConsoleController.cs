using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        private readonly PacketMapper _packetMapper;
        private readonly int _pageSize = Properties.Settings.Default.PageSize;
        private readonly int _pagesSetSize = Properties.Settings.Default.PagesSetSize;

        public ConsoleController()
        {
            _dataMapper = new DataMapper();
            _executor = new Executor(new RealPathManager());
            _packetMapper = new PacketMapper(_executor, _dataMapper);
            _context = new LaboratoriumContext();
        }

        private List<PacketItem> GetPacketItems(PacketEntity packet)
        {
            var currentUserId = User.Identity.GetUserId();
            var packets = _context
                .Packets
                .Where(s =>
                (s.IsPublic || s.AspNetUserId == currentUserId) &&
                s.IsReusable &&
                s.Id != packet.Id)
                .Include(s => s.AspNetUser);

            var list = _dataMapper.Map<List<PacketEntity>, List<PacketItem>>(packets.ToList());

            return list;
        }

        [HttpGet]
        public ActionResult Index(int id = 0, bool copy = false)
        {
            var model = new PacketViewModel();

            if (id == 0)
            {
                model = _dataMapper.Map<Packet, PacketViewModel>(_executor.GetNewEmptyPacket());
                model.Packets = GetPacketItems(new PacketEntity());
            }
            else
            {
                var currentUserId = User.Identity.GetUserId();
                
                var packetEntity = _context.Packets.FirstOrDefault(p => p.Id == id);
                if (packetEntity == null)
                {
                    RedirectToAction("Error", "Home");
                }

                if (User.IsInRole("User") && packetEntity.AspNetUserId != currentUserId)
                {
                    RedirectToAction("Error", "Home");
                }

                if (packetEntity != null)
                {
                    if (copy)
                    {
                        packetEntity = _dataMapper.Map<PacketEntity, PacketEntity>(packetEntity);
                        packetEntity.Title = $"Копия \"{packetEntity.Title}\"";
                        packetEntity.Id = 0;
                        packetEntity.AspNetUser = null;
                        packetEntity.AspNetUserId = User.Identity.GetUserId();
                        _context.Packets.Add(packetEntity);
                        _context.SaveChanges();

                        return RedirectToAction("Index", new { id = packetEntity.Id });
                    }

                    var packet = _packetMapper.Map(packetEntity, GetPacketItems(packetEntity));

                    if (!packet.IsError)
                    {
                        packet = _executor.Execute(packet);
                    }

                    model = _dataMapper.Map<Packet, PacketViewModel>(packet);
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PacketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsError = true;
                return View(model);
            }

            switch (model.PacketAction)
            {
                case PacketAction.New:
                    return RedirectToAction("Index", new { id = 0 });
                case PacketAction.Execute:
                    var packet = _dataMapper.Map<PacketViewModel, Packet>(model);
                    packet = _executor.Execute(packet);
                    model = _dataMapper.Map<Packet, PacketViewModel>(packet);
                    return View(model);
                case PacketAction.Save:
                    if (string.IsNullOrEmpty(model.Title) || string.IsNullOrWhiteSpace(model.Title))
                    {
                        model.Result.Add("Необходимо указать название Вашего пакета");
                        return View(model);
                    }
                    if (model.IsReusable && (model.Packets.Any(p => p.IsEnadled) || model.Modules.Any(m => m.IsEnadled)))
                    {
                        model.Result.Add("Переиспользуемый пакет на данный момент не может иметь зависимых пакетов или модулей");
                        return View(model);
                    }
                    if (model.IsPublic && model.Packets.Any(p => p.IsEnadled && !p.IsPublic))
                    {
                        model.Result.Add("Общедоступный пакет не может иметь зависимых не общедоступных пакетов");
                        return View(model);
                    }

                    var packetEntity = _packetMapper.Map(model);

                    if (packetEntity.Id > 0 && _context.Packets.Find(packetEntity.Id).AspNetUserId != User.Identity.GetUserId() && User.IsInRole("User"))
                    {
                        model.Result.Add("Вы не можете изменять чужой пакет. Пожалуйста, сделайте копию и сохраните её.");
                        return View(model);
                    }

                    if (packetEntity.Id == 0)
                    {
                        packetEntity.AspNetUserId = User.Identity.GetUserId();
                    }
                    else
                    {
                        packetEntity.AspNetUserId = _context.Packets.Find(packetEntity.Id).AspNetUserId;
                    }

                    _context.Packets.AddOrUpdate(packetEntity);
                    _context.SaveChanges();

                    return RedirectToAction("Index", new { id = packetEntity.Id });
                case PacketAction.Load:
                    return RedirectToAction("LoadPacket");
                case PacketAction.Delete:
                    var unnecessaryPacket = _context.Packets.Find(model.Id);

                    if (unnecessaryPacket.AspNetUserId == User.Identity.GetUserId() || User.IsInRole("Admin"))
                    {
                        _context.Packets.Remove(unnecessaryPacket);
                        _context.SaveChanges();
                    }
                    else
                    {
                        model.Result.Add("Вы не можете удалить чужой пакет.");
                        return View(model);
                    }
                    return RedirectToAction("LoadPacket");
                case PacketAction.Copy:
                    return RedirectToAction("Index", new { id = model.Id, copy = true });
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
                (s.Script ?? "").Contains(codePattern) &&
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
            var currentUserId = User.Identity.GetUserId();
            var packetEntity = _context.Packets.Include(s => s.AspNetUser).FirstOrDefault(s => s.Id == id && (s.AspNetUserId == currentUserId || s.IsPublic));
            if (packetEntity == null)
            {
                return View("Error");
            }

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