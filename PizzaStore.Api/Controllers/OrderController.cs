using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStoreAPi.Models;
using PizzaStoreAPi.Repositories;
using ViewModels.DtoClasses;

namespace PizzaStoreAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repository;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> Get()
        {
            var orders = await _repository.GetAllOrdersAsync();
            return orders;
        }
        
        [HttpPost]
        public ActionResult Post(OrderDto order)
        {
            try
            {
                _repository.AddOrder(order);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}