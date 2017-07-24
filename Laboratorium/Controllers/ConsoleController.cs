using System.Web.Mvc;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;

namespace Laboratorium.Controllers
{
    [Authorize]
    public class ConsoleController : Controller
    {
        private readonly Executor _executor;

        public ConsoleController()
        {
            _executor = new Executor(new RealPathManager());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Console()
        {
            var packet = _executor.GetNewEmptyPacket();
            return PartialView(packet);
        }

        [HttpPost]
        public ActionResult Console(Packet packet)
        {
            packet = _executor.Execute(packet);
            return PartialView(packet);
        }
    }
}