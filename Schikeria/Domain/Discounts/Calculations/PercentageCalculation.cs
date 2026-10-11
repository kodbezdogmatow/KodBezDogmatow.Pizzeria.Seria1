using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Domain.Discounts.Calculations
{
    public class PercentageCalculation :
        DiscountCalculationBase
    {
        public override CalculationType CalculationType => CalculationType.Percentage;

        public override decimal Calculate(Discount discount, Order order)
        {
            return order.TotalPrice * (1 - discount.Value);
        }
    }
}
