using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var accountsListItems = new List<AccountsListItem>();
            var users = _context.AspNetUsers.OrderBy(u => u.LastName);

            foreach (var aspNetUser in users)
            {
                var user = _dataMapper.Map<AspNetUser, AccountsListItem>(aspNetUser);
                user.Role = GetRoleName(aspNetUser.AspNetRoles.First().Name);
                accountsListItems.Add(user);
            }

            return View(accountsListItems);
        }

        private string GetRoleName(string id)
        {
            switch (id)
            {
                case "Admin":
                    return @"Администратор";
                case "User":
                    return @"Пользователь";
                default:
                    return "Ошибка!";
            }
        }

        [HttpGet]
        public ActionResult ManageUserAccount(string id)
        {
            var user = _context.AspNetUsers.Find(id);
            var model = _dataMapper.Map<AspNetUser, AccountsListItem>(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeUserData(string id)
        {
            var user = _context.AspNetUsers.Find(id);
            var model = _dataMapper.Map<AspNetUser, AccountsListItem>(user);

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeUserData(AccountsListItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.AspNetUsers.First(u => u.Id == model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Patronymic = model.Patronymic;
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