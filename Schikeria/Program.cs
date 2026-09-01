using Schikeria.Managers.Toppings;
using Schikeria.Model.Pizzas;
using Schikeria.Services.Pizzas;


//10 % rabatu dla zamówień powyżej 100 zł,
//15% rabatu dla studentów,
//20% rabatu w poniedziałek.
//20% dla VIP.

//Na razie rabaty się nie łączą — obowiązuje jeden, najwyższy rabat.

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

var maxPizzaMenuNumber = pizzas.Count;
if (int.TryParse(Console.ReadLine(), out int selectedPizzaMenuNumber) &&
    selectedPizzaMenuNumber <= maxPizzaMenuNumber)
{
    var selectedPizzaIndex = selectedPizzaMenuNumber - 1;
    selectedPizza = pizzas[selectedPizzaIndex];
}

if (selectedPizza == null)
{
    Console.WriteLine("Niewlasciwy wybor pizzy");
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

if (int.TryParse(Console.ReadLine(), out int selectedSizeMenuNumber) &&
    Enum.IsDefined(typeof(Sizes), selectedSizeMenuNumber))
{
    selectedSize = (Sizes)selectedSizeMenuNumber;
}

if (selectedSize == Sizes.None)
{
    Console.WriteLine("Niewlasciwy wybor rozmiaru");
    return;
}

var toppingManager = new Manager();
var toppingInfos = toppingManager.GetForMenu(selectedPizza);

foreach (var info in toppingInfos)
{
    Console.WriteLine($"[{info.MenuNumber}]: {info.Name}");
}

Console.WriteLine("[Q]: Wyjscie");

var toppingInput = Console.ReadLine();

if (!toppingInput.Contains("Q"))
{
    var toppingMenuNumbers = toppingInput
        .Split(",", StringSplitOptions.RemoveEmptyEntries);

    var maxToppingMenuNumber = toppingInfos.Count;

    foreach (var menuNumber in toppingMenuNumbers)
    {
        if (int.TryParse(menuNumber, out int selectedToppingMenuNumber) &&
            selectedToppingMenuNumber <= maxToppingMenuNumber)
        {
            var selectedToppingInfoIndex = selectedToppingMenuNumber - 1;
            var selectedToppingInfo = toppingInfos[selectedToppingInfoIndex];

            if (selectedPizza.Toppings
                .Any(t => t.Name == selectedToppingInfo.Name))
            {
                continue;
            }

            var selectedTopping = toppingManager
                .Get(selectedToppingInfo.Name);

            selectedPizza.Toppings.Add(selectedTopping);
        }
        else
        {
            Console.WriteLine("Niewlasciwy wybor dodatku");
            return;
        }
    }
}

Console.WriteLine($"{selectedPizza.Name}, {selectedSize}");
selectedPizza.Toppings
    .ForEach(t => Console.WriteLine($"{t.Name}"));

Console.ReadLine();