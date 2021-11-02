using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PizzaStoreRazor.Models;

namespace PizzaStoreRazor.Pages
{
    public class PizzaStoreRepository
    {
        public Order Order { get; set; } = new Order();
        public async Task<List<Pizza>> GetPizzaFromApi()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/Pizza");
            var pizza = await httpResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var res = JsonSerializer.Deserialize<List<Pizza>>(pizza, options);

            return res;
        }

        public async Task<List<Topping>> GetToppingFromApi()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/Topping");
            var topping = await httpResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var res = JsonSerializer.Deserialize<List<Topping>>(topping, options);

            return res;
        }
        
        public async Task PostOrderToApi(Order order)
        {
            var httpClient = new HttpClient();
            var body = JsonSerializer.Serialize(order);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync("https://localhost:5001/Order", requestContent);
        }
        
        public void OnGet()
        {
        }
    }
}