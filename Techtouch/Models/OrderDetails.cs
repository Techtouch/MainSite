using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Techtouch.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Orders Order { get; set; }
    }
}