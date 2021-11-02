using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using ViewModels.DtoClasses;
using ViewModels.Persistence;

namespace PizzaStoreRazor.Pages.Shared
{
    public class OrderHistory : PageModel
    {
        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var adapter = new DataAccessAdapter();
            var meta = new LinqMetaData(adapter);
            var orders = await meta.Order.ProjectToOrderViewModel().ToListAsync();
            return orders;
        }
    }
}