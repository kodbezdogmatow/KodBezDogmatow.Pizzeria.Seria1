using Schikeria.Interfaces.Common;
using Schikeria.Interfaces.Providers.Rules.Pizzas.Sizes;
using Schikeria.Interfaces.Rules.Pizzas.Sizes;
using Schikeria.Interfaces.Services.Duplications;
using Schikeria.Providers.Bases;
using Schikeria.Services.Duplications;

namespace Schikeria.Providers.Rules.Pizzas.Sizes
{
    public class NotAvailabilityRuleProvider :
        ImplementationProvider, 
        INotAvailabilityRuleProvider
    {
        private readonly IDuplicationService _duplicationService = new DuplicationService();

        public List<INotAvailabilityRuleBase> Get()
        {
            var rules = GetImplementations<INotAvailabilityRuleBase>();

            var result = _duplicationService.Get(
                rules.ConvertAll<IUniqueKey>(r => r));

            if (result.Count > 1)
            {
                // TODO: Komunikat bardziej pod uzytkownika z szczegolami
                throw new ArgumentException("Duplikaty regul.");
            }

            return rules;
        }
    }
}
