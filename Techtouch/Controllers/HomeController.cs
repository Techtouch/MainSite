using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Techtouch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A little Something About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Have any Questions?";

            return View();
        }
    }
}