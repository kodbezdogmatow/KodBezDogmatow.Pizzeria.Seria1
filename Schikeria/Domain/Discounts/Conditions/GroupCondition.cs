using Schikeria.Guards;
using Schikeria.Interfaces.Domain.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Domain.Discounts.Conditions
{
    public class GroupCondition :
        IDiscountCondition
    {
        public DiscountKind Kind => DiscountKind.Group;

        public bool IsSatisfied(Discount discount, Order order)
        {
            var groupDiscount = CastGuard.CastOrThrow<GroupDiscount>(discount);

            return order.TotalCount >= groupDiscount.MinCount;
        }
    }
}
