using Schikeria.Model.Pizzas;
using Schikeria.Providers;
using Schikeria.Services.Pizzas;

var displayService = new DisplayService();
var pizzas = new PizzaProvider().Get();

foreach (var pizza in pizzas)
{
    displayService.Display(pizza);
}

var yourPiizaSalami = pizzas
    .First(p => p.Name == Names.Salami);
var yourPiizaPepperoni = pizzas
    .First(p => p.Name == Names.Pepperoni);

Console.WriteLine($"Twoja Pizza:");

displayService.Display(yourPiizaSalami, Sizes.Medium);
displayService.Display(yourPiizaPepperoni, Sizes.Large);

Console.ReadLine();