using Schikeria.Interfaces.Providers.Discounts.Conditions;
using Schikeria.Interfaces.Services.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Services.Discounts.Conditions
{
    public class ConditionService :
        IConditionService
    {
        private readonly IConditionProvider _conditionProvider;

        public ConditionService(
            IConditionProvider conditionProvider)
        {
            _conditionProvider = conditionProvider;
        }

        public bool IsSatisfied(
            Discount discount,
            Order order)
        {
            var result = true;
            var condition = _conditionProvider
                .Get()
                .FirstOrDefault(c => c.Kind == discount.Kind);

            if (condition != null)
            {
                result = condition.IsSatisfied(discount, order);
            }

            return result;
        }
    }
}
