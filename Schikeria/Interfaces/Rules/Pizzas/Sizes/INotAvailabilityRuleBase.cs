using Schikeria.Model.Pizzas;

namespace Schikeria.Interfaces.Rules.Pizzas.Sizes
{
    public interface INotAvailabilityRuleBase
    {
        string PizzaName { get; }
        Model.Pizzas.Sizes Size { get; }

        bool IsSatisfied(Pizza pizza);
    }
}