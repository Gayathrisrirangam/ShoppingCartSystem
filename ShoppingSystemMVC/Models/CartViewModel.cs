using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemMVC.Models
{
    public class CartViewModel
    {
        public int CartID { get; set; }
        public int ItemID { get; set; }
        public int AddQuantity { get; set; }
        public int RemoveQuantity { get; set; }
    }
}