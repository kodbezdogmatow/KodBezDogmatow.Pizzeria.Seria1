using Schikeria.Interfaces.Rules.Pizzas.Sizes;

namespace Schikeria.Rules.Pizzas.Sizes
{
    public abstract class NotAvailabilityRuleBase :
        INotAvailabilityRuleBase
    {
        // TODO: Refactoring
        public abstract string PizzaName { get; }
        public abstract Model.Pizzas.Sizes Size { get; }

        // TODO: Context dla reguly?
        public bool IsSatisfied(string pizzaName, Model.Pizzas.Sizes size)
        {
            return SpecifyIsSatisfied(pizzaName, size);
        }

        protected abstract bool SpecifyIsSatisfied(
            string pizzaName, Model.Pizzas.Sizes size);

        public string GetUniqueKey()
        {
            return $"{PizzaName}_{Size}";
        }
    }
}
