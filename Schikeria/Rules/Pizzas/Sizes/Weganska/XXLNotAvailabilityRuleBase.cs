using Schikeria.Constants.Pizzas;
using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Weganska
{
    public class XXLNotAvailabilityRuleBase :
        NotAvailabilityRuleBase
    {
        public override string PizzaName => Names.Weganska;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        protected override bool SpecifyIsSatisfied(Pizza pizza)
        {
            return pizza.Name == PizzaName && pizza.CurrentSize == Size;
        }
    }
}
