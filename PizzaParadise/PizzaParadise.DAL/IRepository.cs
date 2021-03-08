using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.DAL
{
    public interface IRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(string first, string last);

        bool customerExists(string first, string last);

        String GetCustomerNameById(int id);
        void AddCustomer(Customer customer);
        List<Product> GetAllProducts();

        Product GetProductById(int ProductId);
        void AddProductToOrder(Product p, int quantity);
        void CreateOrder(int CustomerId, int StoreId);

        void AddTotalToOrder();

        List<Store> GetStores();

        Store getStore(int id);

        List<OrderLine> GetOrderDetailsByOrderId(int id);

        List<Order> GetOrdersByLocation(int locationId);
        List<Order> GetCustomerOrdersById(int customerId);

        Order GetLastOrder();
        List<OrderLine> GetLastOrderDetails();
    }
}
