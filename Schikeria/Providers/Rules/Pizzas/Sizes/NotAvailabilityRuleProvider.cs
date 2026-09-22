using Schikeria.Interfaces.Rules.Pizzas.Sizes;
using Schikeria.Providers.Bases;

namespace Schikeria.Providers.Rules.Pizzas.Sizes
{
    public class NotAvailabilityRuleProvider :
        ImplementationProvider
    {
        public List<INotAvailabilityRuleBase> Get()
        {
            return GetImplementations<INotAvailabilityRuleBase>();
        }
    }
}
