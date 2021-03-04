using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaParadise.DAL
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
