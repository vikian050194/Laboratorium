﻿using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult PackageForm()
        {
            return PartialView(new Packet());
        }

        [HttpPost]
        public ActionResult PackageForm(Packet packet)
        {
            var executor = new Executor(new RealPathManager());
            packet = executor.Execute(packet, false);

            return PartialView(packet);
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