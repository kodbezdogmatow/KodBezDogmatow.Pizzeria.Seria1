using Schikeria.Interfaces.Factories.Prices;
using Schikeria.Interfaces.Providers.Prices;
using Schikeria.Interfaces.Services.Prices;
using Schikeria.Model.Prices;

namespace Schikeria.Services.Prices
{
    public class PriceListDefinitionService : 
        IPriceListDefinitionService
    {
        private readonly IPriceListFactory _priceListFactory;
        private readonly IHardcodedPizzaPriceProvider _hardcodedPizzaPriceProvider;

        // TODO: Po testach jednostkowych usunac ten konstruktor, dopoki nie mamy DI nie generujemy
        // kodu, ktory utrudni nam pozniej prace przy wdrozeniu DI.
        public PriceListDefinitionService(
            IPriceListFactory priceListFactory,
            IHardcodedPizzaPriceProvider hardcodedPizzaPriceProvider) 
        { 
            _priceListFactory = priceListFactory;
            _hardcodedPizzaPriceProvider = hardcodedPizzaPriceProvider;
        }

        public PriceList Define()
        {
            var priceList = _priceListFactory.Create();

            // Ustawienie ceny
            priceList.Items
                .ForEach(i => i.Price = _hardcodedPizzaPriceProvider.Get(i.PizzaName, i.Size));

            return priceList;
        }
    }
}
