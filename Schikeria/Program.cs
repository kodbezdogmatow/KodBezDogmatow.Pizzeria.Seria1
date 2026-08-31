using Schikeria.Managers.Toppings;
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

var toppingManager = new Manager();
var toppingInfos = toppingManager.GetForMenu();

foreach (var info in toppingInfos)
{
    Console.WriteLine($"[{info.MenuNumber}]: {info.Name}");
}


var toppingInput = Console.ReadLine();

var toppingMenuNumbers = toppingInput!
    .Split(",", StringSplitOptions.RemoveEmptyEntries);

foreach (var menuNumber in toppingMenuNumbers)
{
    if (int.TryParse(menuNumber, out int selectedToppingMenuNumber))
    {
        var selectedToppingInfoIndex = selectedToppingMenuNumber - 1;
        var selectedToppingInfo = toppingInfos[selectedToppingInfoIndex];
        var selectedTopping = toppingManager
            .Get(selectedToppingInfo.Name);

        selectedPizza.Toppings.Add(selectedTopping);
    }
}

Console.WriteLine($"{selectedPizza.Name}, {selectedSize}");
selectedPizza.Toppings
    .ForEach(t => Console.WriteLine($"{t.Name}"));

Console.ReadLine();