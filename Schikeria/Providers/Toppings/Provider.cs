using Schikeria.Model.Toppings;

namespace Schikeria.Providers.Toppings
{
    public class Provider
    {
        public List<Topping> Get()
        {
            return [
                    new Topping
                    {
                        Name = "Ham",
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = "Salami",
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = "Mushrooms",
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = "Onions",
                        Price = 1m,
                    },
                    new Topping
                    {
                        Name = "Olives",
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = "Pepperoni",
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = "Chicken",
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = "Mozzarella",
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = "BellPepper",
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = "Pineapple",
                        Price = 1.5m,
                    },
                ];
        }
    }
}
