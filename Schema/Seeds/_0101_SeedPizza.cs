using FluentMigrator;

namespace Schema
{
    [Migration(101)]
    public class _0101_SeedPizza : AutoReversingMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Pizza")
                .Row(new
                { 
                    Name = "Cheddar Cheese", Price = 105, Ingredients = "Our pizza sauce combined with authentic Cheddar cheese and Mozzarella."
                })
                .Row(new
                {
                    Name = "Hot & Spicy", Price = 115,
                    Ingredients = "Italian Sausage, Tomato, Onions, Green Pepper, Jalapeno"
                })
                .Row(new
                {
                    Name = "Little Italy", Price = 130,
                    Ingredients = "Pepperoni, Italian Sausage, Fresh Mushroom, Black Olives, Oregano"
                })
                .Row(new
                {
                    Name = "Chicken BBQ", Price = 130,
                    Ingredients = "Grilled Chicken, Onions, Fresh Mushroom, BBQ Sauce"
                })
                .Row(new
                {
                    Name = "Cha Cha", Price = 130,
                    Ingredients = "Grilled Chicken, Chicken Sausage, Onions, Green Pepper"
                })
                .Row(new
                {
                    Name = "Mexican Ole", Price = 130,
                    Ingredients = "Grilled Chicken, Tomato, Onions, Green Pepper, Fresh Mushroom, Jalapeno"
                })
                .Row(new
                {
                    Name = "Chicken Ranch", Price = 135,
                    Ingredients = "Grilled Chicken, Tomato, Fresh Mushroom, Ranch Sauce"
                })
                .Row(new
                {
                    Name = "Margherita", Price = 100, Ingredients = "Mozzarella Cheese and Pizza Sauce"
                });
        }
    }
}