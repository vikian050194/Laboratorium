using System.Collections.Generic;
using System.Web.Mvc;
using LaboratoriumCore;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Query());
        }

        [HttpPost]
        public ActionResult Index(Query query)
        {
            var executor = new Executor();
            query.Answer = executor.Execute(query.Question);
            query.Answer = executor.Foo();
            return View("Index", query);
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

    public class Query
    {
        public Query()
        {
            Answer = new List<string>();
        }
        public string Question { get; set; }
        public List<string> Answer { get; set; }
    }
}