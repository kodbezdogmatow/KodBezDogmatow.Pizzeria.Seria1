using Schikeria.Interfaces.Common;
using Schikeria.Model.Pizzas;

namespace Schikeria.Interfaces.Rules.Pizzas.Sizes
{
    public interface INotAvailabilityRuleBase :
        IUniqueKey
    {
        string PizzaName { get; }
        Model.Pizzas.Sizes Size { get; }

        bool IsSatisfied(Pizza pizza);
    }
}