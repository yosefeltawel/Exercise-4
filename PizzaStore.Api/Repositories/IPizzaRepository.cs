using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public interface IPizzaRepository
    {
        Task<List<PizzaDto>> GetAllPizzasAsync();
    }
}