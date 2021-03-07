using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PizzaParadise.Library;

namespace PizzaParadise.DAL
{
    public class Repository
    {
        private readonly DbContextOptions<PizzaParadiseContext> _options;

        public Repository()
        {
            using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
            string connectionString = File.ReadAllText("C:/revature/Project1cs.txt");
            _options = new DbContextOptionsBuilder<PizzaParadiseContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Debug)
                .Options;

        }

        public List<Customer> GetAllCustomers()
        {
            using var context = new PizzaParadiseContext(_options);

            List<Customer> entries = context.Customers
                   .Select(x => x).ToList();

            return entries;
        }
        public Customer SearchCustomerByName(string first, string last)
        {
            using var context = new PizzaParadiseContext(_options);

            Customer entry = context.Customers
                .Select(c => c)
                .Where(c => c.FirstName == first && c.LastName == last).First();

            return entry;
        }
        public String GetCustomerNameById(int id)
        {
            using var context = new PizzaParadiseContext(_options);

            Customer entry = context.Customers
                .Select(c => c)
                .Where(c => c.CustomerId == id).First();

            return entry.FirstName + " " + entry.LastName;
        }
        public void AddCustomer(Customer customer)
        {
            using var context = new PizzaParadiseContext(_options);


            var entry = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            List <Customer> customerList = GetAllCustomers();

            foreach(Customer c in customerList)
            {
                if(c.FirstName == entry.FirstName && c.LastName == entry.LastName)
                {
                    throw new ArgumentException("Customer Already Exists", nameof(entry));
                }
            }

            context.Add(entry);

            context.SaveChanges();
        }
        public List<Product> GetAllProducts()
        {
            using var context = new PizzaParadiseContext(_options);

            List<Product> entries = context.Products
                   .Select(x => x).ToList();

            return entries;
        }

        public Product GetProductById(int ProductId)
        {
            using var context = new PizzaParadiseContext(_options);

            Product product = context.Products
                .Select(p => p)
                .Where(p => p.ProductId == ProductId).First();
            return product;
        }
        public void AddProductToOrder(Product p, int quantity)
        {
            using var context = new PizzaParadiseContext(_options);
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
            using var context = new PizzaParadiseContext(_options);


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
            using var context = new PizzaParadiseContext(_options);
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


        public List<OrderLine> GetOrderDetailsByOrderId(int id)
        {
            using var context = new PizzaParadiseContext(_options);

            List<OrderLine> entries = context.OrderLines
                .Select(o => o)
                .Where(o => o.OrderId == id).ToList();
            return entries;
        }

        public List<Order> GetOrdersByLocation(int locationId)
        {
            using var context = new PizzaParadiseContext(_options);

            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.StoreId == locationId).ToList();

            return entries;
        }
        public List<Order> GetCustomerOrdersById(int customerId)
        {
            using var context = new PizzaParadiseContext(_options);

            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.CustomerId == customerId).ToList();

            return entries;
        }

        public Order GetLastOrder()
        {
            using var context = new PizzaParadiseContext(_options);

            Order last = context.Orders
                .OrderByDescending(o => o.OrderId).First();
            return last;
        }
        public List<OrderLine> GetLastOrderDetails()
        {
            using var context = new PizzaParadiseContext(_options);
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
