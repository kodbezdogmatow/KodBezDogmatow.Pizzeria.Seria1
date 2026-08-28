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
var yourPiizaWeganska = pizzas
    .First(p => p.Name == Schikeria.Constants.Pizzas.Names.Weganska);
var yourPiizaPepperoni = pizzas
    .First(p => p.Name == Schikeria.Constants.Pizzas.Names.Pepperoni);

var manager = new Manager();

yourPiizaWeganska.Toppings.AddRange(
    manager.GetAllNotMeat());

//var ham = manager.Get(Schikeria.Constants.Toppings.Names.Ham);
//yourPiizaSalami.Toppings.Add(ham);

//var ham1 = manager.Get(Schikeria.Constants.Toppings.Names.Ham);
//yourPiizaPepperoni.Toppings.Add(ham1);

//ham.Price *= 0.9m;


Console.WriteLine($"Twoja Pizza:");

displayService.Display(yourPiizaWeganska, Sizes.Medium);
displayService.Display(yourPiizaPepperoni, Sizes.Large);

Console.ReadLine();