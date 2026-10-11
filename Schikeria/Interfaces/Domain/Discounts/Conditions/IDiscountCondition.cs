using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Interfaces.Domain.Discounts.Conditions
{
    public interface IDiscountCondition
    {
        DiscountKind Kind { get; }

        // TODO: Moze context, sprawdzic jak sie wyklaruje context
        bool IsSatisfied(Discount discount, Order order);
    }
}
