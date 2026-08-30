using Schikeria.Model.Pizzas;
using Schikeria.Services.Pizzas;

// Pizza, Rozmiar, Dodatk(ow)
var displayService = new DisplayService();
var pizzas = new Schikeria.Providers.Pizzas.Provider().Get();
Pizza? selectedPizza = null;
Sizes selectedSize = Sizes.None;

foreach (var pizza in pizzas)
{
    var pizzaMenuNumber = pizzas.IndexOf(pizza) + 1;
    Console.WriteLine($"[{pizzaMenuNumber}]: {pizza.Name}");
}

if (int.TryParse(Console.ReadLine(), out int selectedPizzaMenuNumber))
{
    var selectedPizzaIndex = selectedPizzaMenuNumber - 1;
    selectedPizza = pizzas[selectedPizzaIndex];
}

if (selectedPizza == null)
{
    Console.WriteLine("Niewlasciwy wybor");
    return;
}

var availableSizes = Enum
    .GetValues<Sizes>()
    .Except([Sizes.None])
    .ToList();

foreach (var size in availableSizes)
{
    Console.WriteLine($"[{(int)size}]: {size}");
}

if (int.TryParse(Console.ReadLine(), out int selectedSizeMenuNumber))
{
    var selectedSizeIndex = selectedSizeMenuNumber - 1;
    selectedSize = (Sizes)selectedSizeMenuNumber;
}

if (selectedSize == Sizes.None)
{
    Console.WriteLine("Niewlasciwy wybor");
    return;
}

Console.WriteLine($"{selectedPizza.Name}, {selectedSize}");

Console.ReadLine();