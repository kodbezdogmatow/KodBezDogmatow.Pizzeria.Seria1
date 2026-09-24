using Schikeria.Constants.Pizzas;
using Schikeria.Guards;
using Schikeria.Interfaces.Rules.Pizzas.Hawajska;
using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Hawajska
{
    public class XXLNotAvailabilityRule :
        NotAvailabilityRuleBase
    {
        private IWeekendAvailabilityRule? _weekendAvailabilityRule;

        public override string PizzaName => Names.Hawajska;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        // TECHDEBT: Jak DI bedzie w systemie, to ta metoda zniknie
        public void Initialize(IWeekendAvailabilityRule weekendAvailabilityRule)
        {
            _weekendAvailabilityRule = weekendAvailabilityRule;
        }

        protected override bool SpecifyIsSatisfied(Pizza pizza)
        {
            var weekendAvailabilityRule = NotNullGuard.Ensure(_weekendAvailabilityRule);

            return pizza.Name == PizzaName &&
                pizza.CurrentSize == Size &&
                weekendAvailabilityRule.IsSatisfied();
        }
    }
}
