using Schikeria.Model.Toppings;

namespace Schikeria.Model.Pizzas
{
    public class Pizza
    {
        public Dictionary<Sizes, decimal> Sizes { get; set; } = [];
        public required string Name { get; set; }
        public List<Topping> Toppings { get; set; } = [];
    }
}
