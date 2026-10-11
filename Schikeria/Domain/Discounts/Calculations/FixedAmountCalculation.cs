using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Domain.Discounts.Calculations
{
    public class FixedAmountCalculation :
        DiscountCalculationBase
    {
        public override CalculationType CalculationType => CalculationType.FixedAmount;

        public override decimal Calculate(Discount discount, Order order)
        {
            return order.TotalPrice - discount.Value;
        }
    }
}
