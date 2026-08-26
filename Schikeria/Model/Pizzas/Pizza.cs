namespace Schikeria.Model.Pizzas
{
    public class Pizza
    {
        public Dictionary<Sizes, decimal> Sizes { get; set; } = [];
        public required string Name { get; set; }
    }
}
