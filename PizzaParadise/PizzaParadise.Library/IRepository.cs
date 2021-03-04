using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public interface IRepository
    {
        public Customer GetCustmomerByName(Customer c);
        public List<Customer> GetAllCustomers();
        public void AddCustomer(string fName, string lName);


        public Product GetProduct(int id);

        public List<Product> GetAllProducts();
        public Product AddProduct(Product p);

        public List<Store> GetAllStores();

        public Store GetStore(int s);

        public List<Order> GetAllOrders();

        public Order GetOrder(int id);
        public void PlaceOrder(Order o);

        public List<Order> GetCustomerOrders(Customer c);

        public List<Order> GetStoreOrders(Store s);
    }
}
