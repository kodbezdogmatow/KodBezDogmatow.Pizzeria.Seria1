using Schikeria.Model.Pizzas;

namespace Schikeria.Interfaces.Providers.Prices
{
    public interface IHardcodedPizzaPriceProvider
    {
        decimal Get(string pizzaName, Sizes size);
    }
}