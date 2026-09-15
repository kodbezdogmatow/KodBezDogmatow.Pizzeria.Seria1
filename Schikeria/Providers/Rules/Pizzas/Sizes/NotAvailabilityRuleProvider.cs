using Schikeria.Rules.Pizzas.Sizes;
using Schikeria.Rules.Pizzas.Sizes.Weganska;

namespace Schikeria.Providers.Rules.Pizzas.Sizes
{
    public class NotAvailabilityRuleProvider
    {
        public List<PizzaSizeNotAvailabilityRuleBase> Get()
        {
            return [
                new XXLNotAvailabilityRuleBase()
            ];
        }
    }
}
