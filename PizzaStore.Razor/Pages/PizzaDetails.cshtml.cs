using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaStoreRazor.Models;

namespace PizzaStoreRazor.Pages
{
    public class PizzaDetails : PageModel
    {
        public List<Topping> ToppingList { get; set; }
        public PizzaWithTopping PizzaWithTopping { get; set; } = new PizzaWithTopping();
        [BindProperty] public List<int> Toppings { get; set; }

        public async Task OnGet(int id)
        {
            var repo = new PizzaStoreRepository();
            ToppingList = await repo.GetToppingFromApi();
        }

        public IActionResult OnPost(int id)
        {
            PizzaWithTopping.Id = id;
            PizzaWithTopping.ToppingList = Toppings;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pizzas = TempData["PizzaWithToppings"] as string ?? "[]";
            var res = JsonSerializer.Deserialize<List<PizzaWithTopping>>(pizzas, options);
            res.Add(PizzaWithTopping);

            TempData["PizzaWithToppings"] = JsonSerializer.Serialize(res);


            return RedirectToPage("Index");
        }
    }
}