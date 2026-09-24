using Schikeria.Constants.Pizzas;
using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Diavola
{
    public class SNotAvailabilityRuleBase :
        NotAvailabilityRuleBase
    {
        public override string PizzaName => Names.Diavola;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.Small;

        protected override bool SpecifyIsSatisfied(Pizza pizza)
        {
            return pizza.Name == PizzaName && pizza.CurrentSize == Size;
        }
    }
}
