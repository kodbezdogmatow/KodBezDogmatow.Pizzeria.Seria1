using Schikeria.Model.Pizzas;

namespace Schikeria.Model.Orders
{
    public class OrderItem
    {
        public required Pizza Pizza { get; set; }

        // TODO: Nie moze byc mniejsza niz 1
        public int Count { get; set; }
    }
}
