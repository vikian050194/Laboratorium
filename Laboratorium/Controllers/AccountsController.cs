using System.Web.Mvc;
using Laboratorium.DAL;

namespace Laboratorium.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public AccountsController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}