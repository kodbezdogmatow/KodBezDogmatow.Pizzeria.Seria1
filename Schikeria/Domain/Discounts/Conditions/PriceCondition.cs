using Schikeria.Guards;
using Schikeria.Interfaces.Domain.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Domain.Discounts.Conditions
{
    public class PriceCondition :
        IDiscountCondition
    {
        public DiscountKind Kind => DiscountKind.Price;

        public bool IsSatisfied(Discount discount, Order order)
        {
            var groupDiscount = CastGuard.CastOrThrow<PriceDiscount>(discount);

            return order.TotalPrice >= groupDiscount.MinPrice;
        }
    }
}
