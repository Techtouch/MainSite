//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Techtouch.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int product_id { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public string product_description { get; set; }
        public int product_type_id { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
