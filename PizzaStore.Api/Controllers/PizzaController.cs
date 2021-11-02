using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStoreAPi.Models;
using PizzaStoreAPi.Repositories;

namespace PizzaStoreAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IPizzaRepository _repository;

        public PizzaController(ILogger<PizzaController> logger, IPizzaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<PizzaDto>> Get()
        {
            var pizzas = await _repository.GetAllPizzasAsync();
            return pizzas;
        }
    }
}