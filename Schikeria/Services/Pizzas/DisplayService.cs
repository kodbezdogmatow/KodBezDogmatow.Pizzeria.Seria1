using Schikeria.Model.Pizzas;

namespace Schikeria.Services.Pizzas
{
    public class DisplayService
    {
        public void Display(Pizza pizza)
        {
            Console.WriteLine($"{pizza.Name}:");

            foreach (var sizePrice in pizza.Sizes)
            {
                Console.WriteLine($"\t{sizePrice.Key}: {sizePrice.Value} ZL");
            }
        }

        public void Display(Pizza pizza, Sizes size)
        {
            var price = pizza.Sizes[size];
            Console.WriteLine($"{pizza.Name}: {size}, {price} ZL");

            pizza.Toppings
                .ForEach(t => Console.WriteLine($"\t{t.Name}: {t.Price} ZL"));
        }
    }
}
