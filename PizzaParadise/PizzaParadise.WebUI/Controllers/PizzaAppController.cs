using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaParadise.DAL;
using PizzaParadise.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.WebUI.Controllers
{
    [ApiController]
    public class PizzaAppController : ControllerBase
    {
        private readonly Repository _repository;

        public PizzaAppController()
        {
            _repository = new Repository();
        }

        // distinguish what HTTP method (GET, POST, etc.) this will accept, and, what URL
        [HttpGet("api/menu")]
        public IEnumerable<PizzaParadise.DAL.Product> GetInbox()
        {
            return _repository.List();
        }
    }
}
