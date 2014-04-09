using DomainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly LaptopRepository repository;

        public HomeController(LaptopRepository repository)
        {
            if (repository == null) throw new Exception("HomeController requires a repository");

            this.repository = repository;
        }

        public ActionResult Index()
        {
            LaptopService service = new LaptopService(repository);

            var laptops = service.GetLaptops();

            var model = new LaptopsViewModel();
            model.Laptops = new List<LaptopViewModel>();

            foreach (var laptop in laptops)
            {
                var lvm = new LaptopViewModel(laptop);
                model.Laptops.Add(lvm);
            }
            
            return View(model);
        }

        public ActionResult IndexPDF()
        {
            return View();
        }

        public ActionResult Administrator()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
