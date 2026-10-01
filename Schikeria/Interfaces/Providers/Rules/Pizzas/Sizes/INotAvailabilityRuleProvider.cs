using Schikeria.Interfaces.Rules.Pizzas.Sizes;

namespace Schikeria.Interfaces.Providers.Rules.Pizzas.Sizes
{
    public interface INotAvailabilityRuleProvider
    {
        List<INotAvailabilityRuleBase> Get();
    }
}