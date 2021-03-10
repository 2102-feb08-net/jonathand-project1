using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaParadise.DAL;
using System;
using Microsoft.AspNetCore.Mvc;

namespace PizzaParadise.WebUI.Controllers
{
    [ApiController]
    public class PizzaAppController : ControllerBase
    {
        private readonly IRepository _repository;

        public PizzaAppController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/products")]
        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetAllProducts();
        }
        [HttpPost("api/add-customer")]
        public void addNewCustomer(Customer customer)
        {
            _repository.AddCustomer(customer);
        }

        [HttpGet("api/customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetAllCustomers();
        }

        [HttpGet("api/search-customer/{first}/{last}")]
        public Customer getCustomer(string first, string last)
        {
            return _repository.GetCustomer(first, last);
        }

        [HttpGet("api/stores")]
        public IEnumerable<Store> GetStores()
        {
            return _repository.GetStores();
        }

        [HttpGet("api/get-store/{id}")]
        public Store getStore(int id)
        {
            return _repository.getStore(id);
        }

        [HttpPost("api/order{customerId}/{storeId}")]
        public void createOrder(int customerId, int storeId)
        {
            _repository.CreateOrder(customerId, storeId);
        }
    }
}
