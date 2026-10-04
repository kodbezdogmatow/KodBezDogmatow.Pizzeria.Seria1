using Schikeria.Constants.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Weganska
{
    public class XXLNotAvailabilityRule :
        NotAvailabilityRuleBase
    {
        public override string PizzaName => Names.Weganska;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        protected override bool SpecifyIsSatisfied(
            string pizzaName, Model.Pizzas.Sizes size)
        {
            return pizzaName == PizzaName && size == Size;
        }
    }
}
