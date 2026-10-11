using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Interfaces.Services.Discounts.Conditions
{
    public interface IConditionService
    {
        bool IsSatisfied(Discount discount, Order order);
    }
}