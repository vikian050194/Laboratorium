using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Laboratorium.Core.Managers;
using Laboratorium.DAL;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Laboratorium.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountsController : Controller
    {
        private readonly LaboratoriumContext _context;
        private readonly DataMapper _dataMapper;
        private ApplicationUserManager _userManager;
        private readonly int _pageSize = Properties.Settings.Default.PageSize;
        private readonly int _pagesSetSize = Properties.Settings.Default.PagesSetSize;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountsController()
        {
            _context = new LaboratoriumContext();
            _dataMapper = new DataMapper();
        }

        [HttpGet]
        public ActionResult AccountsList()
        {
            var model = new AccountsInViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AccountsListPartial(AccountsInViewModel inputModel)
        {
            var firstNamePattern = inputModel.Filtering.FirstName ?? "";
            var lastNamePattern = inputModel.Filtering.LastName ?? "";
            var patronymicPattern = inputModel.Filtering.Patronymic ?? "";
            var rolePattern = inputModel.Filtering.Role.ToString();

            var users = _context
                .AspNetUsers
                .Where(u =>
                    u.FirstName.Contains(firstNamePattern) &&
                    u.LastName.Contains(lastNamePattern) &&
                    u.Patronymic.Contains(patronymicPattern) &&
                    u.AspNetRoles.Any(r => r.Id == rolePattern));

            switch (inputModel.Sorting.OrderBy)
            {
                case "FirstName":
                    users = inputModel.Sorting.IsAscending ? users.OrderBy(s => s.FirstName) : users.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    users = inputModel.Sorting.IsAscending ? users.OrderBy(s => s.LastName) : users.OrderByDescending(s => s.LastName);
                    break;
                case "Patronymic":
                    users = inputModel.Sorting.IsAscending ? users.OrderBy(s => s.Patronymic) : users.OrderByDescending(s => s.Patronymic);
                    break;
            }

            var currentPage = inputModel.IsFilterChanged ? 1 : inputModel.CurrentPage;

            var paging = new PagingManager().GetPaging(users.Count(), currentPage, _pageSize, _pagesSetSize);

            var page = users
                .Skip((currentPage - 1) * _pageSize)
                .Take(_pageSize);

            var list = _dataMapper.Map<List<AspNetUser>, List<AccountViewModel>>(page.ToList());

            var outputModel = new AccountsOutViewModel
            {
                Rows = list,
                Paging = paging
            };

            return Json(outputModel);
        }

        [HttpGet]
        public ActionResult ManageUserAccount(string id)
        {
            var user = _context.AspNetUsers.Find(id);
            var model = _dataMapper.Map<AspNetUser, AccountViewModel>(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeUserData(string id)
        {
            var user = _context.AspNetUsers.Find(id);
            var model = _dataMapper.Map<AspNetUser, AccountViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeUserData(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.AspNetUsers.First(u => u.Id == model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Patronymic = model.Patronymic;
            user.AspNetRoles.Clear();
            user.AspNetRoles.Add(_context.AspNetRoles.Find(model.Role.ToString()));
            _context.AspNetUsers.AddOrUpdate(user);
            _context.SaveChanges();

            return RedirectToAction("ManageUserAccount", "Accounts", new { id = model.Id });
        }

        [HttpGet]
        public ActionResult SetPassword(string id)
        {
            var model = _dataMapper.Map<AspNetUser, SetAccountPassword>(_context.AspNetUsers.Find(id));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetAccountPassword model)
        {
            if (ModelState.IsValid)
            {
                var resetToken = await UserManager.GeneratePasswordResetTokenAsync(model.Id);
                var result = await UserManager.ResetPasswordAsync(model.Id, resetToken, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("ManageUserAccount", "Accounts", new { id = model.Id });
                }

                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}