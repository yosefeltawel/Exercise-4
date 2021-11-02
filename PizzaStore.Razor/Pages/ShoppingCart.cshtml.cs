using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaStoreRazor.Models;

namespace PizzaStoreRazor.Pages
{
    public class ShoppingCart : PageModel
    {
        public List<PizzaWithTopping> CartPizzas { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Topping> Toppings { get; set; }

        public async Task OnGet()
        {
            var repo = new PizzaStoreRepository();
            Pizzas = await repo.GetPizzaFromApi();
            Toppings = await repo.GetToppingFromApi();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pizzas = TempData["PizzaWithToppings"] as string ?? "[]";
            var res = JsonSerializer.Deserialize<List<PizzaWithTopping>>(pizzas, options);
            CartPizzas = res;
        }

        public async Task<IActionResult> OnPost()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pizzas = TempData["PizzaWithToppings"] as string ?? "[]";
            var res = JsonSerializer.Deserialize<List<PizzaWithTopping>>(pizzas, options);

            var order = new Order();
            order.Pizzas = res;
            var repo = new PizzaStoreRepository();
            await repo.PostOrderToApi(order);

            TempData.Clear();
            return RedirectToPage("Index");
        }
    }
}