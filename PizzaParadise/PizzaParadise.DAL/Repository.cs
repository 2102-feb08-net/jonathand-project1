﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaParadise.DAL
{
    public class Repository : IRepository
    {
        private readonly PizzaParadiseContext context;

        public Repository(PizzaParadiseContext _context)
        {
            //using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
            //string connectionString = File.ReadAllText("C:/revature/Project1cs.txt");
            //_options = new DbContextOptionsBuilder<PizzaParadiseContext>()
            //    .UseSqlServer(connectionString)
            //    .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
            //    .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Debug)
            //    .Options;
            context = _context;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> entries = context.Customers
                   .Select(x => x).ToList();

            return entries;
        }
        public Customer GetCustomer(string first, string last)
        {
            Customer entry = new();
            if(customerExists(first,last))
            {
                entry = context.Customers
                .Select(c => c)
                .Where(c => c.FirstName == first && c.LastName == last).First();
            }
            else
            {
                throw new ArgumentException("Customer does not exist");
            }

            return entry;
        }

        public bool customerExists(string first, string last)
        {
            List<Customer> customers = GetAllCustomers();
            bool exists = false;
            foreach(Customer c in customers)
            {
                if(c.FirstName == first && c.LastName == last)
                {
                    exists = true;
                }
            }
            return exists;
        }
        public String GetCustomerNameById(int id)
        {
            Customer entry = context.Customers
                .Select(c => c)
                .Where(c => c.CustomerId == id).First();

            return entry.FirstName + " " + entry.LastName;
        }
        public void AddCustomer(Customer customer)
        {
            var entry = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            List <Customer> customerList = GetAllCustomers();

            foreach (Customer c in customerList)
            {
                if (c.FirstName == entry.FirstName && c.LastName == entry.LastName)
                {
                    throw new ArgumentException("Customer Already Exists", nameof(entry));
                }
            }

            context.Add(entry);

            context.SaveChanges();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> entries = context.Products
                   .Select(x => x).ToList();

            return entries;
        }

        public Product GetProductById(int ProductId)
        {
            Product product = context.Products
                .Select(p => p)
                .Where(p => p.ProductId == ProductId).First();
            return product;
        }
        public void AddProductToOrder(Product p, int quantity)
        {
            Order o = GetLastOrder();
            Inventory entry = context.Inventories
                .Select(x => x)
                .Where(x => x.StoreId == o.StoreId && x.ProductId == p.ProductId).First();
            if (quantity > entry.Quantity)
            {
                throw new ArgumentException("Quantity greater than inventory", nameof(quantity));
            }
            else
            {
                entry.Quantity -= quantity;
                context.Inventories.Update(entry);
            }
            //Product dbProduct = context.Products
            //    .Where(d => d.ProductId == p.ProductId).First();
            ////o.AddProductToOrder(p, quantity);
            var productEntry = new OrderLine
            {
                OrderId = o.OrderId,
                ProductId = p.ProductId,
                Quantity = quantity,
            };
            context.Add(productEntry);

            context.SaveChanges();
        }
        public void CreateOrder(int CustomerId, int StoreId)
        {
            var entry = new Order
            {
                CustomerId = CustomerId,
                StoreId = StoreId,
                OrderDate = DateTime.Now
            };


            context.Add(entry);

            context.SaveChanges();
        }

        public void AddTotalToOrder()
        {
            Order or = GetLastOrder();
            decimal total = 0;
            List<OrderLine> entries = context.OrderLines
                .Select(o => o)
                .Where(o => o.OrderId == or.OrderId)
                .ToList();
            foreach (OrderLine o in entries)
            {
                total += GetProductById(o.ProductId).ProductPrice * o.Quantity;
            }
            or.OrderTotal = total;
            context.Orders.Update(or);
            context.SaveChanges();
        }

        public List<Store> GetStores()
        {
            List<Store> entries = context.Stores
                .Select(s => s).ToList();
            return entries;
        }

        public Store getStore(int id)
        {
            Store entry = context.Stores
                .Select(s => s)
                .Where(s => s.StoreId == id).First();
            return entry;
        }

        public List<OrderLine> GetOrderDetailsByOrderId(int id)
        {
            List<OrderLine> entries = context.OrderLines
                .Select(o => o)
                .Where(o => o.OrderId == id).ToList();
            return entries;
        }

        public List<Order> GetOrdersByLocation(int locationId)
        {
            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.StoreId == locationId).ToList();

            return entries;
        }
        public List<Order> GetCustomerOrdersById(int customerId)
        {
            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.CustomerId == customerId).ToList();

            return entries;
        }

        public Order GetLastOrder()
        {
            Order last = context.Orders
                .OrderByDescending(o => o.OrderId).First();
            return last;
        }
        public List<OrderLine> GetLastOrderDetails()
        {
            Order last = GetLastOrder();

            List<OrderLine> entries = context.OrderLines
                .Select(o => o)
                .Where(o => o.OrderId == last.OrderId).ToList();
            return entries;

        }

        //public Order GetOrderById(int id)
        //{
        //    using var context = new ChinookNumberTwoContext(options);

        //    Order o = context.Orders
        //        .Select(o => o)
        //        .Where(o => o.OrderId == id).First();

        //    return o;
        //}
    }
}
