using Schikeria.Constants.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Diavola
{
    public class SNotAvailabilityRuleBase :
        NotAvailabilityRuleBase
    {
        public override string PizzaName => Names.Diavola;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.Small;

        protected override bool SpecifyIsSatisfied(
            string pizzaName, Model.Pizzas.Sizes size)
        {
            return pizzaName == PizzaName && size == Size;
        }
    }
}
