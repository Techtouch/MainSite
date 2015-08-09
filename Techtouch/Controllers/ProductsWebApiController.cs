using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Techtouch.Controllers
{
    public class ProductsWebApiController : ApiController
    {
        // GET: api/ProductsWebApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductsWebApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsWebApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductsWebApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductsWebApi/5
        public void Delete(int id)
        {
        }
    }
}
