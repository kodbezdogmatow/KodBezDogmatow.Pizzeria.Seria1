using Schikeria.Interfaces.Domain.Discounts.Conditions;
using Schikeria.Interfaces.Providers.Discounts.Conditions;
using Schikeria.Providers.Bases;

namespace Schikeria.Providers.Discounts.Conditions
{
    public class ConditionProvider :
        ImplementationProvider, 
        IConditionProvider
    {
        public List<IDiscountCondition> Get()
        {
            return GetImplementations<IDiscountCondition>();
        }
    }
}
