using Schikeria.Guards;
using Schikeria.Interfaces.Providers.Rules.Pizzas.Sizes;
using Schikeria.Model.Pizzas;
using Schikeria.Providers.Rules.Pizzas.Sizes;

namespace Schikeria.Services.Pizzas
{
    public class SizeAvailabilityService
    {
        private readonly INotAvailabilityRuleProvider _provider = new NotAvailabilityRuleProvider();

        public bool Validate(Pizza pizza)
        {
            ValidEnumGuard.Against(pizza.CurrentSize);

            var result = true;

            var rule = _provider
                .Get()
                .FirstOrDefault(r =>
                    r.PizzaName == pizza.Name &&
                    r.Size == pizza.CurrentSize);

            if (rule != null)
            {
                // ! Regula biznesowa sprawzda czy pizza jest NIEdostepna, dlatego negacja podczas przypisywania
                result = !rule.IsSatisfied(pizza);
            }

            return result;
        }
    }
}
