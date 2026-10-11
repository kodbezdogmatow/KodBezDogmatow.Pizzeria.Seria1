using Schikeria.Interfaces.Domain.Discounts.Calculations;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Domain.Discounts.Calculations
{
    public abstract class DiscountCalculationBase :
        IDiscountCalculation
    {
        public abstract CalculationType CalculationType { get; }

        public abstract decimal Calculate(Discount discount, Order order);

        public string GetUniqueKey()
        {
            return CalculationType.ToString();
        }
    }
}
