//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingSystemMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ItemPrice { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
