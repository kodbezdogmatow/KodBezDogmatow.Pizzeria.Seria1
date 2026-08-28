using Schikeria.Managers.Toppings;
using Schikeria.Model.Pizzas;
using Schikeria.Services.Pizzas;

var displayService = new DisplayService();
var pizzas = new Schikeria.Providers.Pizzas.Provider().Get();

//foreach (var pizza in pizzas)
//{
//    displayService.Display(pizza);
//}

// Test szefa
var yourPiizaSalami = pizzas
    .First(p => p.Name == Names.Salami);
var yourPiizaPepperoni = pizzas
    .First(p => p.Name == Names.Pepperoni);

var manager = new Manager();

var ham = manager.Get("Ham");
yourPiizaSalami.Toppings.Add(ham);

var ham1 = manager.Get("Ham");
yourPiizaPepperoni.Toppings.Add(ham1);

ham.Price *= 0.9m;


Console.WriteLine($"Twoja Pizza:");

displayService.Display(yourPiizaSalami, Sizes.Medium);
displayService.Display(yourPiizaPepperoni, Sizes.Large);

Console.ReadLine();