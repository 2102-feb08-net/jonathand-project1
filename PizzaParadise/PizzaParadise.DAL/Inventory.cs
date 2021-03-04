using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaParadise.DAL
{
    public partial class Inventory
    {
        public int InventoryLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
