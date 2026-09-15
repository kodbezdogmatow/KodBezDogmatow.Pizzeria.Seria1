using Schikeria.Model.Pizzas;
using Schikeria.Rules.Pizzas.Sizes;

namespace Schikeria.Services.Pizzas
{
    public class SizeAvailabilityService
    {
        private readonly List<PizzaSizeNotAvailabilityRuleBase> _rules = [];

        public bool Validate(Pizza pizza, Sizes size)
        {
            var result = true;

            // TODO: FirstOrDefault jest nieszczesliwe w tym przypadku. Walidacja czy sa duplkiaty
            var rule = _rules
                .FirstOrDefault(r =>
                    r.PizzaName == pizza.Name &&
                    r.Size == size);

            if (rule != null)
            {
                // ! Regula biznesowa sprawzda czy pizza jest NIEdostepna, dlatego negacja podczas przypisywania
                result = !rule.IsSatisfied(pizza);
            }

            return result;
        }
    }
}
