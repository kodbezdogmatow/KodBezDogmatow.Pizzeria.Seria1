using Schikeria.Model.Pizzas;

namespace Schikeria.Model.Prices
{
    public class PriceListItem
    {
        public required string PizzaName { get; set; }
        public required Sizes Size { get; set; }
        public decimal Price { get; set; }
    }
}
