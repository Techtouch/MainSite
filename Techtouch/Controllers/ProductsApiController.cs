using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Techtouch.Models;

namespace Techtouch.Controllers
{
    public class ProductsApiController : ApiController
    {
        private TechTouchieEntities db = new TechTouchieEntities();

        // GET: api/ProductsApi
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }


        public IEnumerable<Product> GetBestProducts(int count)
        {
            var products = db.Products.ToList().OrderByDescending(m => m.product_price).Take(count).ToList();
            if (products == null || !products.Any())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return products;
        }

        public IEnumerable<Product> GetCheapestProducts(int count)
        {
            var products = db.Products.ToList().OrderBy(m => m.product_price).Take(count).ToList();
            if (products == null || !products.Any())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return products;
        }

        // GET: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}