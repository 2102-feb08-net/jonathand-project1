using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Store
    {
        private int storeId { get; set; }
        private string storeName { get; set; }

        public List<Order> Orders { get; set; }

        public Dictionary<int, int> StoreInventory { get; set; }

        public Store(int store)
        {
            storeId = store;
            Orders = new List<Order>();
            //StoreInventory = new Inventory();
        }

        public void RemoveFromInventory(Product p, int amount)
        {   
            if(amount > StoreInventory[p.ProductId - 1])
            {
                throw new ArgumentException("Amount is larger than product inventory", nameof(amount));
            }
            else 
            {
                StoreInventory[p.ProductId - 1] -= amount;
            }
        }
        public int StoreId
        {
            get => storeId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0", nameof(value));
                }
                storeId = value;
            }
        }

        public string StoreName
        {
            get => storeName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Product name must not be empty.", nameof(value));
                }
                storeName = value;
            }
        }
    }
}
