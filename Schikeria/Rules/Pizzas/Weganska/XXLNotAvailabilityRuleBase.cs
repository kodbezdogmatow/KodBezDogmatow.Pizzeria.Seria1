using Schikeria.Constants.Pizzas;
using Schikeria.Model.Pizzas;
using Schikeria.Rules.Pizzas.Sizes;

namespace Schikeria.Rules.Pizzas.Weganska
{
    public class XXLNotAvailabilityRuleBase :
        PizzaSizeNotAvailabilityRuleBase
    {
        public override string PizzaName => Names.Weganska;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        protected override bool SpecifyIsSatisfied(Pizza pizza)
        {
            return pizza.Name == PizzaName && pizza.CurrentSize == Size;
        }
    }
}
