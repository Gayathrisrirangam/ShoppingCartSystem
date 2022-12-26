using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystemMVC.Models
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }
        public string CategoryID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ItemPrice { get; set; }

    }

}