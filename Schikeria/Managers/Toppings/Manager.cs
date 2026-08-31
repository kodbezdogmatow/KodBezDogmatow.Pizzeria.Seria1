using Schikeria.Model.Pizzas;
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
                        Name = Constants.Toppings.Names.Ham,
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Salami,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Mushrooms,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Onions,
                        Price = 1m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Olives,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Pepperoni,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Chicken,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Mozzarella,
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.BellPepper,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Constants.Toppings.Names.Pineapple,
                        Price = 1.5m,
                    }
                ];
        }

        public Topping Get(string name)
        {
            return _toppings.First(x => x.Name == name);
        }

        public List<MenuToppingInfo> GetForMenu(Pizza pizza)
        {
            var allToppings = _toppings;

            if (pizza.Name == Constants.Pizzas.Names.Weganska)
            {
                allToppings = GetAllNonMeat();
            }

            return allToppings
                .Select(t => new MenuToppingInfo
                {
                    Name = t.Name,
                    MenuNumber = allToppings.IndexOf(t) + 1,
                })
                .ToList();
        }

        private List<Topping> GetAllNonMeat()
        {
            return _toppings
                .Where(t =>
                    t.Name != Constants.Toppings.Names.Pepperoni &&
                    t.Name != Constants.Toppings.Names.Chicken &&
                    t.Name != Constants.Toppings.Names.Ham &&
                    t.Name != Constants.Toppings.Names.Salami)
                .ToList();
        }
    }
}
