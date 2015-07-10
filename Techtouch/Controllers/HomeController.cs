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
        private TechtouchConnection db = new TechtouchConnection();
        public ActionResult Index()
        {
            ViewBag.HeaderImage = "~/Content/Images/header.jpg";

            var products = db.Products.ToList().OrderByDescending(m => m.product_price).Take(5);
            return View(products);
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