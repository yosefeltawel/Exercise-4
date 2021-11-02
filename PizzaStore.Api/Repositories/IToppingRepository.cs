using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public interface IToppingRepository
    {
        Task<List<ToppingDto>> GetAllToppingsAsync();
    }
}