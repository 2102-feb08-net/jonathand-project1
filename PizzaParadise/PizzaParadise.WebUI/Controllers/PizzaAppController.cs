using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaParadise.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.WebUI.Controllers
{
    [ApiController]
    public class PizzaAppController : ControllerBase
    {
        private readonly PizzaParadise.DAL.Repository _repository;

        public PizzaAppController()
        {
            _repository = new PizzaParadise.DAL.Repository();
        }

        [HttpGet("api/products")]
        public IEnumerable<PizzaParadise.DAL.Product> GetProducts()
        {
            return _repository.GetAllProducts();
        }
        [HttpPost("api/add-customer")]
        public void addNewCustomer(PizzaParadise.DAL.Customer customer)
        {
            _repository.AddCustomer(customer);
        }
    }
}
