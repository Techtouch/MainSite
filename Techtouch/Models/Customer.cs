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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_password { get; set; }
        public string customer_email { get; set; }
        public string customer_country { get; set; }
        public string customer_city { get; set; }
        public string customer_post { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
