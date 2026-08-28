using Schikeria.Model.Toppings;

namespace Schikeria.Managers.Toppings
{
    public class Manager
    {
        private readonly List<Topping> _toppings;

        public Manager()
        {
            _toppings = [
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
                    }
                ];
        }

        public Topping Get(string name)
        {
            return _toppings.First(x => x.Name == name);
        }
    }
}
