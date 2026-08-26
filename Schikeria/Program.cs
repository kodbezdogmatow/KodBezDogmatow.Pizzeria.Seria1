using Schikeria.Providers;

// Rozmiary: Small, Medium, Large.

var pizzas = new PizzaProvider().Get();

foreach (var pizza in pizzas)
{
    Console.WriteLine($"{pizza.Name}: {pizza.Price} ZL, {pizza.Size}");
}

Console.ReadLine();