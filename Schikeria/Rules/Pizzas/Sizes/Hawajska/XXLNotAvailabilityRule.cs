using Schikeria.Constants.Pizzas;
using Schikeria.Guards;
using Schikeria.Interfaces.Rules.Pizzas.Hawajska;

namespace Schikeria.Rules.Pizzas.Sizes.Hawajska
{
    public class XXLNotAvailabilityRule :
        NotAvailabilityRuleBase
    {
        private readonly IWeekendAvailabilityRule? _weekendAvailabilityRule;

        public override string PizzaName => Names.Hawajska;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        protected override bool SpecifyIsSatisfied(
            string pizzaName, Model.Pizzas.Sizes size)
        {
            var weekendAvailabilityRule = NotNullGuard.Against(_weekendAvailabilityRule);

            return pizzaName == PizzaName &&
                size == Size &&
                weekendAvailabilityRule.IsSatisfied();
        }
    }
}
