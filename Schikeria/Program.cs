using Schikeria;
using Schikeria.Providers;

new PizzaProvider()
    .Get()
    .ForEach(DisplayService.Display);

//foreach(var pizza in pizzas)
//{
//    Console.WriteLine($"{pizza.Name}: {pizza.Price} ZL");
//}

Console.ReadLine();