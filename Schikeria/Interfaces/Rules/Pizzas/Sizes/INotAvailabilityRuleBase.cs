using Schikeria.Interfaces.Common;

namespace Schikeria.Interfaces.Rules.Pizzas.Sizes
{
    public interface INotAvailabilityRuleBase :
        IUniqueKey
    {
        string PizzaName { get; }
        Model.Pizzas.Sizes Size { get; }

        bool IsSatisfied(string pizzaName, Model.Pizzas.Sizes size);
    }
}