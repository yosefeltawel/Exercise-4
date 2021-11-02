using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Data.Linq;
using PizzaStoreAPi.Models;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace PizzaStoreAPi.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        public async Task<List<PizzaDto>> GetAllPizzasAsync()
        {
            using var adapter = new DataAccessAdapter();
            var meta = new LinqMetaData(adapter);
            var pizzas = await meta.Pizza.ToListAsync();
            return pizzas.ConvertAll(p => p.Adapt<PizzaDto>());
        }
    }
}