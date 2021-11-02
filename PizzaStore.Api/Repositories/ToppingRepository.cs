using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Data.Linq;
using PizzaStoreAPi.Models;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace PizzaStoreAPi.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        public async Task<List<ToppingDto>> GetAllToppingsAsync()
        {
            using var adapter = new DataAccessAdapter();
            var meta = new LinqMetaData(adapter);
            var toppings = await meta.Topping.ToListAsync();
            return toppings.ConvertAll(t => t.Adapt<ToppingDto>());
        }
    }
}