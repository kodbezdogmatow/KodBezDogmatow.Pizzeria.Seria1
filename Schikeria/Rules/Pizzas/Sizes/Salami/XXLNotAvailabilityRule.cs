using Schikeria.Constants.Pizzas;
using Schikeria.Guards;
using Schikeria.Interfaces.Rules.Pizzas.Salami;

namespace Schikeria.Rules.Pizzas.Sizes.Salami
{
    public class XXLNotAvailabilityRule :
        NotAvailabilityRuleBase
    {
        private readonly IUnavailableAfterHouerRule? _unavailableAfterHouerRule;

        public override string PizzaName => Names.Salami;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        protected override bool SpecifyIsSatisfied(
            string pizzaName, Model.Pizzas.Sizes size)
        {
            var unavailableAfterHouerRule = NotNullGuard.Against(_unavailableAfterHouerRule);
            return pizzaName == PizzaName &&
                size == Size &&
                unavailableAfterHouerRule.IsSatisfied();
        }
    }
}
