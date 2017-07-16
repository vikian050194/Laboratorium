using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Laboratorium.DAL;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountsController : Controller
    {
        private readonly LaboratoriumContext _context;
        private readonly DataMapper _dataMapper;

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
                user.Role = aspNetUser.AspNetRoles.First().Name;
                accountsListItems.Add(user);
            }

            return View(accountsListItems);
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
    }
}