namespace Schikeria.Model.Pizzas
{
    public class Pizza
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public Sizes Size { get; set; }
    }
}
