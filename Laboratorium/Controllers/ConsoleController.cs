using System.Web.Mvc;
using Laboratorium.Core;
using Laboratorium.Core.Managers;
using Laboratorium.Data;

namespace Laboratorium.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly DataMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly Executor _executor;

        public ConsoleController(IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = new DataMapper();
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
            packet = _executor.Execute(packet, true);
            return PartialView(packet);
        }
    }
}