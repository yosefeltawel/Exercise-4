using System.Collections.Generic;

namespace PizzaStoreAPi.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<PizzaWithToppingDto> Pizzas { get; set; } = new List<PizzaWithToppingDto>();
        public string Note { get; set; }

        // public decimal TotalCost { get; set; }
    }
}