using System.IO;
using System.Web.Mvc;
using Laboratorium.Core.Managers;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HowToUse()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Examples()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Books()
        {
            return View();
        }

        [HttpGet]
        public FileResult DownloadDevGuide()
        {
            var pathManager = new RealPathManager();

            var fileBytes = System.IO.File.ReadAllBytes(Path.Combine(pathManager.AssembliesDirectory, Properties.Settings.Default.Guide));

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(Properties.Settings.Default.Guide));
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}