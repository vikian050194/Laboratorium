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
            var fileName = "Laboratorium.DevGuide.pdf";
            var fileBytes = System.IO.File.ReadAllBytes(pathManager.AssembliesDirectory + @"..\..\Guides\" + fileName);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}