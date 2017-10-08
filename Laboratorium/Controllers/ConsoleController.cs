using System.Collections.Generic;
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

namespace Laboratorium.Controllers
{
    [Authorize]
    public class ConsoleController : Controller
    {
        private readonly LaboratoriumContext _context;
        private readonly DataMapper _dataMapper;
        private readonly Executor _executor;
        private const int _pageSize = 2;
        private const int _pagesMaxToShow = 2;

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
                    return RedirectToAction("LoadFromDbIndex");
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
        public ActionResult LoadFromDbIndex()
        {
            var model = new ScriptsInViewModel();

            return View("LoadFromDb", model);
        }

        [HttpPost]
        public ActionResult LoadFromDbPartial(ScriptsInViewModel inputModel)
        {
            var titlePattern = inputModel.Filtering.Title ?? "";
            var codePattern = inputModel.Filtering.Code ?? "";
            var authorPattern = inputModel.Filtering.Author ?? "";

            var scripts = _context
                .Scripts
                .Where(s =>
                !s.IsPrivate &&
                s.Title.Contains(titlePattern) &&
                s.Code.Contains(codePattern) &&
                s.AspNetUser.LastName.Contains(authorPattern))
                .Include(s => s.AspNetUser);

            switch (inputModel.Sorting.OrderBy)
            {
                case "Title":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.Title) : scripts.OrderByDescending(s => s.Title);
                    break;
                case "Code":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.Code) : scripts.OrderByDescending(s => s.Code);
                    break;
                case "Author":
                    scripts = inputModel.Sorting.IsAscending ? scripts.OrderBy(s => s.AspNetUser.LastName) : scripts.OrderByDescending(s => s.AspNetUser.LastName);
                    break;
            }

            var totalCount = scripts.Count();
            var totalPages = totalCount / _pageSize;

            //scripts.Skip((inputModel.CurrentPage - 1) * _pageSize)s
            //.Take(_pageSize)
            //.ToList();

            var list = _dataMapper.Map<List<Script>, List<ScriptViewModel>>(scripts.ToList());

            var outputModel = new ScriptsOutViewModel
            {
                Rows = list,
                Paging = new PagingViewModel
                {
                    CurrentPage = 1,
                    IsNextEnabled = true,
                    IsPreviousEnabled = false,
                    Pages = new List<int> { 1, 2 }
                }
            };

            return Json(outputModel);
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