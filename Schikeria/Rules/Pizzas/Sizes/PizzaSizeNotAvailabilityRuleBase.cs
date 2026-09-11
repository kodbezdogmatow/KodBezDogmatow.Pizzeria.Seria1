using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes
{
    public abstract class PizzaSizeNotAvailabilityRuleBase
    {
        public bool IsSatisfied(
            Pizza pizza, 
            Model.Pizzas.Sizes sizes)
        {
            return SpecifyIsSatisfied(pizza, sizes);
        }

        protected abstract bool SpecifyIsSatisfied(
            Pizza pizza, 
            Model.Pizzas.Sizes sizes);
    }
}
