using Schikeria.Model.Pizzas;
using Schikeria.Providers;

var pizzas = new PizzaProvider().Get();

foreach (var pizza in pizzas)
{
    Console.WriteLine($"{pizza.Name}: {pizza.Price} ZL, {pizza.Size}");
}

var yourPizza = pizzas
    .First(p => 
        p.Name == Names.SalamiPepperoni &&
        p.Size == Sizes.Large);

Console.WriteLine($"Twoja Pizza: {yourPizza.Name}: {yourPizza.Price} ZL, {yourPizza.Size}");

Console.ReadLine();