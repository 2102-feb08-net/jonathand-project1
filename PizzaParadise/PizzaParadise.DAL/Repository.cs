using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaParadise.DAL
{
    public class Repository : IRepository
    {
        private readonly PizzaParadiseContext context;

        public Repository(PizzaParadiseContext _context)
        {

            context = _context;
        }

        /// <summary>
        /// Gets a list of all of the customers in the database.
        /// </summary>
        /// <returns>Returns a list of the customers found in the database.</returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> entries = context.Customers
                   .Select(x => x).ToList();

            return entries;
        }

        /// <summary>
        /// Gets the customer with the specified first and last name.
        /// </summary>
        /// <param name="first">The first name of the customer.</param>
        /// <param name="last">The last name of the customer.</param>
        /// <returns>Returns the custome found.</returns>
        public Customer GetCustomer(string first, string last)
        {
            Customer entry = new();
            if (customerExists(first, last))
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

        /// <summary>
        /// Checks if a customer with the specified first and last name exists.
        /// </summary>
        /// <param name="first">The first name of the customer.</param>
        /// <param name="last">The last name of the customer.</param>
        /// <returns>Returns True if the customer is found, false otherwise.</returns>
        public bool customerExists(string first, string last)
        {
            List<Customer> customers = GetAllCustomers();
            bool exists = false;
            foreach (Customer c in customers)
            {
                if (c.FirstName == first && c.LastName == last)
                {
                    exists = true;
                }
            }
            return exists;
        }

        /// <summary>
        /// Gets a customer's name based on their Id.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <returns>Returns the full name of the customer formated with a space between the first and last name.</returns>
        public String GetCustomerNameById(int id)
        {
            Customer entry = context.Customers
                .Select(c => c)
                .Where(c => c.CustomerId == id).First();

            return entry.FirstName + " " + entry.LastName;
        }

        /// <summary>
        /// Add a customer to the database.
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            var entry = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            List<Customer> customerList = GetAllCustomers();

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

        /// <summary>
        /// Get all of the products in the database.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            List<Product> entries = context.Products
                   .Select(x => x).ToList();

            return entries;
        }

        /// <summary>
        /// Get the product with the specified product Id.
        /// </summary>
        /// <param name="ProductId">The Id of the product.</param>
        /// <returns>Returns a product object with the Id.</returns>
        public Product GetProductById(int ProductId)
        {
            Product product = context.Products
                .Select(p => p)
                .Where(p => p.ProductId == ProductId).First();
            return product;
        }

        /// <summary>
        /// Adds a product with the specified quantity to the order.
        /// </summary>
        /// <param name="p">The product to add to the order.</param>
        /// <param name="quantity">The quantity to add.</param>
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

        /// <summary>
        /// Creates an order with the specified customer and store Id.
        /// </summary>
        /// <param name="CustomerId">The Id of the customer.</param>
        /// <param name="StoreId">The Id of the store.</param>
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

        /// <summary>
        /// Calculates and sets the order total for the last order created.
        /// </summary>
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

        /// <summary>
        /// Gets all of the stores in the database.
        /// </summary>
        /// <returns>Returns a list of stores in</returns>
        public List<Store> GetStores()
        {
            List<Store> entries = context.Stores
                .Select(s => s).ToList();
            return entries;
        }

        /// <summary>
        /// Gets the store with the specified Id.
        /// </summary>
        /// <param name="id">The Id of the store.</param>
        /// <returns>Returns the store with the Id.</returns>
        public Store getStore(int id)
        {
            Store entry = context.Stores
                .Select(s => s)
                .Where(s => s.StoreId == id).First();
            return entry;
        }

        /// <summary>
        /// Gets all of the orderlines with the specified order Id.
        /// </summary>
        /// <param name="id">The Id of the order.</param>
        /// <returns>Returns a list of orderlines.</returns>
        public List<OrderLine> GetOrderDetailsByOrderId(int id)
        {
            List<OrderLine> entries = context.OrderLines
                .Select(o => o)
                .Where(o => o.OrderId == id).ToList();
            return entries;
        }

        /// <summary>
        /// Gets all orders from a specified store location.
        /// </summary>
        /// <param name="locationId">The Id of the store location.</param>
        /// <returns>Returns a list of orders form the stor location</returns>
        public List<Order> GetOrdersByLocation(int locationId)
        {
            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.StoreId == locationId).ToList();

            return entries;
        }

        /// <summary>
        /// Gets all orders from a specified customer.
        /// </summary>
        /// <param name="customerId">The Id of the customer.</param>
        /// <returns>Returns a list of orders.</returns>
        public List<Order> GetCustomerOrdersById(int customerId)
        {
            List<Order> entries = context.Orders
                .Select(o => o)
                .Where(o => o.CustomerId == customerId).ToList();

            return entries;
        }

        /// <summary>
        /// Gets last order made, which is the order with the highest order Id.
        /// </summary>
        /// <returns>Returns the last order Id.</returns>
        public Order GetLastOrder()
        {
            Order last = context.Orders
                .OrderByDescending(o => o.OrderId).First();
            return last;
        }

        /// <summary>
        /// Gets the details of the last order.
        /// </summary>
        /// <returns>Returns a list of orderlines for the order.</returns>
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