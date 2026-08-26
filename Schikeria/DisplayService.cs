using Schikeria.Model;

namespace Schikeria
{
    public static class DisplayService
    {
        public static void Display(Pizza pizza)
        {
            Console.WriteLine($"{pizza.Name}: {pizza.Price} ZL");
        }
    }
}
