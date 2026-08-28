using Schikeria.Model.Toppings;

namespace Schikeria.Factories.Toppings
{
    public class Factory
    {
        public Topping Create(string name)
        {
            var topping = new Topping
            {
                Name = name,
            };

            switch (topping.Name)
            {
                case "Onions": topping.Price = 1m; break;
                case "BellPepper":
                case "Mushrooms":
                case "Olives":
                case "Pineapple": topping.Price = 1.5m; break;
                case "Ham":
                case "Mozzarella": topping.Price = 2m; break;
                case "Pepperoni":
                case "Salami":
                case "Chicken": topping.Price = 2.5m; break;
            }

            return topping;
        }
    }
}
