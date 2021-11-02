using System.Collections.Generic;

namespace PizzaStore.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public List<PizzaResponse> OrderPizzas { get; set; }
        public decimal TotalCost { get; set; }

        public class Pizza
        {
            public int Id { get; set; }
            public decimal Price { get; set; }
            public string Name { get; set; }
        }

        public class PizzaWithTopping
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int ToppingId { get; set; }
        }

        public class PizzaResponse
        {
            public Pizza Pizza { get; set; }
            public int PizzaId { get; set; }
            public List<PizzaWithTopping> PizzaWithToppings { get; set; }
        }
    }
}