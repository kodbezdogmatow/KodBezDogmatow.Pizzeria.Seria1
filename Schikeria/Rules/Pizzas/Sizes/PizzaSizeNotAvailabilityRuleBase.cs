using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes
{
    public abstract class PizzaSizeNotAvailabilityRuleBase
    {
        // TODO: Refactoring
        public string PizzaName { get; set; }
        public Model.Pizzas.Sizes Sizes { get; set; }

        public bool IsSatisfied(Pizza pizza)
        {
            return SpecifyIsSatisfied(pizza);
        }

        protected abstract bool SpecifyIsSatisfied(
            Pizza pizza);
    }
}
