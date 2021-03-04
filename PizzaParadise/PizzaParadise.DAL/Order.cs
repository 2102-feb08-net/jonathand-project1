using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaParadise.DAL
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
