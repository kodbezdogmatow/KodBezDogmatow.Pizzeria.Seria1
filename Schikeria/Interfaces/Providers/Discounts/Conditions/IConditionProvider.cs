using Schikeria.Interfaces.Domain.Discounts.Conditions;

namespace Schikeria.Interfaces.Providers.Discounts.Conditions
{
    public interface IConditionProvider
    {
        List<IDiscountCondition> Get();
    }
}