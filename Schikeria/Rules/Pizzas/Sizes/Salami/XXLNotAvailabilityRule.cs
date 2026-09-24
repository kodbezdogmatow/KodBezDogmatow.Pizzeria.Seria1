using Schikeria.Constants.Pizzas;
using Schikeria.Guards;
using Schikeria.Interfaces.Rules.Pizzas.Salami;
using Schikeria.Model.Pizzas;

namespace Schikeria.Rules.Pizzas.Sizes.Salami
{
    public class XXLNotAvailabilityRule :
        NotAvailabilityRuleBase
    {
        private IUnavailableAfterHouerRule? _unavailableAfterHouerRule;

        public override string PizzaName => Names.Salami;

        public override Model.Pizzas.Sizes Size => Model.Pizzas.Sizes.XXL;

        // TECHDEBT: Jak DI bedzie w systemie, to ta metoda zniknie
        public void Initialize(IUnavailableAfterHouerRule unavailableAfterHouerRule)
        {
            _unavailableAfterHouerRule = unavailableAfterHouerRule;
        }

        protected override bool SpecifyIsSatisfied(Pizza pizza)
        {
            var unavailableAfterHouerRule = NotNullGuard.Ensure(_unavailableAfterHouerRule);
            return pizza.Name == PizzaName && 
                pizza.CurrentSize == Size &&
                unavailableAfterHouerRule.IsSatisfied();
        }
    }
}
