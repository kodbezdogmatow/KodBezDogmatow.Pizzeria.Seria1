using Schikeria.Interfaces.Factories.Prices;
using Schikeria.Interfaces.Providers.Pizzas;
using Schikeria.Interfaces.Services.Pizzas;
using Schikeria.Model.Prices;
using Schikeria.Providers.Pizzas;
using Schikeria.Services.Pizzas;

namespace Schikeria.Factories.Prices
{
    public class PriceListFactory :
        IPriceListFactory
    {
        private readonly ISizeAvailabilityService _sizeAvailabilityService = new SizeAvailabilityService();
        private readonly INameProvider _nameProvider = new NameProvider();
        private readonly ISizeProvider _sizeProvider = new SizeProvider();

        public PriceListFactory(
            INameProvider nameProvider,
            ISizeProvider sizeProvider,
            ISizeAvailabilityService sizeAvailabilityService)
        {
            _nameProvider = nameProvider;
            _sizeProvider = sizeProvider;
            _sizeAvailabilityService = sizeAvailabilityService;
        }

        public PriceList Create()
        {
            var names = _nameProvider.GetAll();
            var sizes = _sizeProvider.GetAll();
            var result = new PriceList();

            foreach (var name in names)
            {
                foreach (var size in sizes)
                {
                    // Sprawdzenie czy jest dana pizza akurat dostepna w tym rozmiarz
                    if (_sizeAvailabilityService.Validate(name, size))
                    {
                        result.Items.Add(new PriceListItem
                        {
                            PizzaName = name,
                            Size = size,
                            Price = 0
                        });
                    }
                }
            }

            return result;
        }
    }
}
