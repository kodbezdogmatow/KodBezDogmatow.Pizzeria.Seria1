using Schikeria.Interfaces.Rules.Pizzas.Sizes;
using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes
{
    public abstract class NotAvailabilityRuleBase :
        INotAvailabilityRuleBase
    {
        // TODO: Refactoring
        public abstract string PizzaName { get; }
        public abstract Model.Pizzas.Sizes Size { get; }

        public bool IsSatisfied(Pizza pizza)
        {
            return SpecifyIsSatisfied(pizza);
        }

        protected abstract bool SpecifyIsSatisfied(
            Pizza pizza);
    }
}
