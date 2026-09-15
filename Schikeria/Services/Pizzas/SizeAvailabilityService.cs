using Schikeria.Model.Pizzas;
using Schikeria.Providers.Rules.Pizzas.Sizes;

namespace Schikeria.Services.Pizzas
{
    public class SizeAvailabilityService
    {
        private readonly NotAvailabilityRuleProvider _provider = new NotAvailabilityRuleProvider();

        public bool Validate(Pizza pizza)
        {
            // TODO: Sprawdz czy current size jest stawiony?
            var result = true;

            // TODO: FirstOrDefault jest nieszczesliwe w tym przypadku. Walidacja czy sa duplkiaty
            // TODO: Uzycj providera
            //var rule = _rules
            //    .FirstOrDefault(r =>
            //        r.PizzaName == pizza.Name &&
            //        r.Size == pizza.CurrentSize);

            //if (rule != null)
            //{
            //    // ! Regula biznesowa sprawzda czy pizza jest NIEdostepna, dlatego negacja podczas przypisywania
            //    result = !rule.IsSatisfied(pizza);
            //}

            return result;
        }
    }
}
