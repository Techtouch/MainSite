using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Techtouch.Models;

namespace Techtouch.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private TechTouchieEntities db = new TechTouchieEntities();
        public ActionResult Index()
        {
            ViewBag.HeaderImage = "~/Content/Images/header.jpg";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.PanelHeading1 = "A little Something About Us";
            ViewBag.PanelHeading2 = "A letter to you";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Have any Questions?";

            return View();
        }
    }
}