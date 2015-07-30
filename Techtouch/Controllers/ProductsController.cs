using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Techtouch.Models;

namespace Techtouch.Controllers
{
    public class ProductsController : Controller
    {
        private TechTouchieEntities db = new TechTouchieEntities();
        public static string IMAGE_LOC = HostingEnvironment.ApplicationPhysicalPath + "/Content/product_images/";
        public static string[] IMAGE_TYPES = { ".jpeg", ".jpg", ".png", ".gif" };

        // GET: Products
        public ActionResult Index(string productType, string searchString, string sortBy, string sortOrder)
        {
            var productList = new List<string>();


            var products = db.Products.Include(p => p.ProductType);

            if (!String.IsNullOrEmpty(searchString))
            {
                products = db.Products.Where(s => s.product_name.Contains(searchString));
            }


            if (!string.IsNullOrEmpty(productType))
            {
                products = db.Products.Where(x => x.ProductType.ToString() == productType);
            }

            
            sortBy = String.IsNullOrEmpty(sortBy) ? "name" : sortBy.ToLower();
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder.ToLower();

            if (sortBy == "price")
            {
                ViewBag.priceSortOrder = (sortOrder == "desc") ? "asc" : "desc";
                ViewBag.nameSortOrder = "asc";
            }
            else
            {
                ViewBag.nameSortOrder = (sortOrder == "desc") ? "asc" : "desc";
                ViewBag.priceSortOrder = "asc";
            }
            string sortKey = sortBy + "_" + sortOrder;
            switch (sortKey)
            {
                case "price_asc":
                    products = products.OrderBy(s => s.product_price);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.product_name);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.product_price);
                    break;
                default:
                    products = products.OrderBy(s => s.product_name);
                    break;
            }

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.product_type_id = new SelectList(db.ProductTypes, "product_type_id", "product_type");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "product_id,product_name,product_price,product_description,product_type_id,product_image")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    product.product_image = Guid.NewGuid().ToString() + "type_start_" + upload.ContentType + "_type_end" + System.IO.Path.GetExtension(upload.FileName);
                    upload.SaveAs(IMAGE_LOC + product.product_image);
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_type_id = new SelectList(db.ProductTypes, "product_type_id", "product_type", product.product_type_id);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_type_id = new SelectList(db.ProductTypes, "product_type_id", "product_type", product.product_type_id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_price,product_description,product_type_id,product_image")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                if (upload != null && upload.ContentLength > 0)
                {
                    product.product_image = Guid.NewGuid().ToString() + "type_start_" + upload.ContentType +"_type_end" + System.IO.Path.GetExtension(upload.FileName);
                    upload.SaveAs(IMAGE_LOC + product.product_image);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_type_id = new SelectList(db.ProductTypes, "product_type_id", "product_type", product.product_type_id);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product.product_image != null)
            {
                System.IO.File.Delete(IMAGE_LOC + product.product_image);
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
