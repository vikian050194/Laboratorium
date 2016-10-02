using System.IO;
using System.Linq;
using System.Web.Mvc;
using Laboratorium.Models.ViewModels;
using LaboratoriumCore;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Item());
        }

        [HttpPost]
        public ActionResult Index(Item item)
        {
            var executor = new Executor();
            item.Result = executor.Execute(item.Query);
            return View("Index", item);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}