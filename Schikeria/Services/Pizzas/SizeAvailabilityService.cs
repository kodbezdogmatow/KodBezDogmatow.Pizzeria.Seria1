using Schikeria.Guards;
using Schikeria.Interfaces.Providers.Rules.Pizzas.Sizes;
using Schikeria.Interfaces.Services.Pizzas;
using Schikeria.Model.Pizzas;
using Schikeria.Providers.Rules.Pizzas.Sizes;

namespace Schikeria.Services.Pizzas
{
    public class SizeAvailabilityService : 
        ISizeAvailabilityService
    {
        private readonly INotAvailabilityRuleProvider _provider = new NotAvailabilityRuleProvider();

        public bool Validate(string name, Sizes size)
        {
            ValidEnumGuard.Against(size);

            var result = true;

            var rule = _provider
                .Get()
                .FirstOrDefault(r =>
                    r.PizzaName == name &&
                    r.Size == size);

            if (rule != null)
            {
                // ! Regula biznesowa sprawzda czy pizza jest NIEdostepna, dlatego negacja podczas przypisywania
                result = !rule.IsSatisfied(name, size);
            }

            return result;
        }
    }
}
