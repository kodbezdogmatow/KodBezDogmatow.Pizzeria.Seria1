using Schikeria.Model.Pizzas;

namespace Schikeria.Providers
{
    public class PizzaProvider
    {
        public List<Pizza> Get()
        {
            return [
                // CODE SMELl
                new Pizza
                {
                    Name = Names.Margherita,
                    Price = 22.5m,
                    Size = Sizes.Small
                },
                new Pizza
                {
                    Name = Names.Margherita,
                    Price = 25,
                    Size = Sizes.Medium
                },
                new Pizza
                {
                    Name = Names.Margherita,
                    Price = 31,
                    Size = Sizes.Large
                },
                new Pizza
                {
                    Name = Names.SalamiPepperoni,
                    Price = 28.5m,
                    Size = Sizes.Small
                },
                new Pizza
                {
                    Name = Names.SalamiPepperoni,
                    Price = 30,
                    Size = Sizes.Medium
                },
                new Pizza
                {
                    Name = Names.SalamiPepperoni,
                    Price = 34.7m,
                    Size = Sizes.Large
                },
                new Pizza
                {
                    Name = Names.Hawajska,
                    Price = 27,
                    Size = Sizes.Small
                },
                new Pizza
                {
                    Name = Names.Hawajska,
                    Price = 32,
                    Size = Sizes.Medium
                },
                new Pizza
                {
                    Name = Names.Hawajska,
                    Price = 34,
                    Size = Sizes.Large
                }];
        }
    }
}
