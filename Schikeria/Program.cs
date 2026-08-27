using Schikeria.Model.Pizzas;
using Schikeria.Services.Pizzas;

//Pizza może mieć dodatki.
//Dodatek wpływa na cenę pizzy.
//Ham 2.00
//Salami	2.50
//Mushrooms	1.50
//Onions	1.00
//Olives	1.50
//Pepperoni	2.50
//Chicken	2.50
//Mozzarella	2.00
//BellPepper	1.50
//Pineapple	1.50

// 1. Provider
// - dostarcza dodatki zdefiniowane w naszym systemie
// - umozliwa edycje listy dodatkow
// - elastyczny jesli chodzi o instancje konkretnych dodatkow

// 2. Manager
// - hermentyzacja listy dodatkow
// - nieumozliwa edycje listy dodatkow

// 3. Factory
// - tworzy za kazdym razem nowy dodatek

var displayService = new DisplayService();
var pizzas = new Schikeria.Providers.Pizzas.Provider().Get();

foreach (var pizza in pizzas)
{
    displayService.Display(pizza);
}

// Test szefa
var yourPiizaSalami = pizzas
    .First(p => p.Name == Names.Salami);
var yourPiizaPepperoni = pizzas
    .First(p => p.Name == Names.Pepperoni);

Console.WriteLine($"Twoja Pizza:");

displayService.Display(yourPiizaSalami, Sizes.Medium);
displayService.Display(yourPiizaPepperoni, Sizes.Large);

Console.ReadLine();