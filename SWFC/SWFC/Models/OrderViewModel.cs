using System;
using System.Collections.Generic;


namespace SWFC.Models
{
    public class OrderViewModel
    {
        public string Username { get; set; }

        public double TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        //public List<Product> Products { get; set; }
        //public List<Order> Orders { get; set; }
        public List<OrderProductViewModel> OrderProductvm { get; set; }
    }
}