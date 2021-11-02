using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PizzaStoreRazor.Models;

namespace PizzaStoreRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Pizza> PizzaList { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            var repo = new PizzaStoreRepository();
            PizzaList = await repo.GetPizzaFromApi();
        }

        public void OnPost()
        {
            
        }
    }
}