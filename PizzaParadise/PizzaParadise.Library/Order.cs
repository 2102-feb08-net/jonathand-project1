using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Order
    {
        private int orderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public Dictionary<Product, int> OrderEntries { get; set; }

        public DateTimeOffset OrderTime { get; set; }


        public Order(int id, int storeId, int customerId)
        {
            orderId = id;
            StoreId = storeId;
            CustomerId = customerId;
            OrderEntries = new Dictionary<Product, int>();
        }

        public Order( int storeId, int customerId)
        {
            StoreId = storeId;
            CustomerId = customerId;
            OrderEntries = new Dictionary<Product, int>();
        }

        public Order()
        {
            OrderEntries = new Dictionary<Product, int>();
        }
        public double OrderTotal
        {
            get
            {
                double total = 0.0;
                foreach (KeyValuePair<Product, int> entry in OrderEntries)
                {
                    total += entry.Key.Price * entry.Value;
                }
                return total;
            }
        }

        public int GetProductAmount(int id)
        {
            int amount = 0;
            foreach(KeyValuePair<Product, int> entry in OrderEntries)
            {
                if(entry.Key.ProductId == id)
                {
                    amount = entry.Value;
                }
            }
            return amount;
        }
        public int OrderId
        {
            get => orderId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0", nameof(value));
                }
                orderId = value;
            }
        }
    }

}
