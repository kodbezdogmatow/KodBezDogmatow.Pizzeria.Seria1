using Schikeria.Model.Pizzas;

namespace Schikeria.Providers
{
    public class PizzaProvider
    {
        public List<Pizza> Get()
        {
            return [
                new Pizza
                {
                    Name = "Margherita",
                    Price = 25
                },
                new Pizza
                {
                    Name = "Salami/Pepperoni",
                    Price = 30
                },
                 new Pizza
                {
                    Name = "Hawajska",
                    Price = 32
                },
                ];
        }
    }
}
