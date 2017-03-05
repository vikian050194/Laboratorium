using System.Web.Mvc;
using Laboratorium.Models.ViewModels;
using Laboratorium.Core;
using Laboratorium.Core.Managers;
using Laboratorium.Data;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataMapper _mapper;
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;

            _mapper = new DataMapper();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult HowToUse()
        {
            return View();
        }

        public ActionResult Examples()
        {
            return View();
        }

        public ActionResult Books()
        {
            return View();
        }
    }
}