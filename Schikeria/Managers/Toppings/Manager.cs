using Schikeria.Constants.Toppings;
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
                        Name = Names.Ham,
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = Names.Salami,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Names.Mushrooms,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Names.Onions,
                        Price = 1m,
                    },
                    new Topping
                    {
                        Name = Names.Olives,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Names.Pepperoni,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Names.Chicken,
                        Price = 2.5m,
                    },
                    new Topping
                    {
                        Name = Names.Mozzarella,
                        Price = 2m,
                    },
                    new Topping
                    {
                        Name = Names.BellPepper,
                        Price = 1.5m,
                    },
                    new Topping
                    {
                        Name = Names.Pineapple,
                        Price = 1.5m,
                    }
                ];
        }

        public Topping Get(string name)
        {
            return _toppings.First(x => x.Name == name);
        }

        // TODO: Zmien nazwe na bardziej opisowa i prawidlowa gramatycznie
        public List<Topping> GetAllNotMeat()
        {
            return _toppings
                .Where(t =>
                    t.Name != Names.Pepperoni &&
                    t.Name != Names.Chicken &&
                    t.Name != Names.Ham &&
                    t.Name != Names.Salami)
                .ToList();
        }
    }
}
