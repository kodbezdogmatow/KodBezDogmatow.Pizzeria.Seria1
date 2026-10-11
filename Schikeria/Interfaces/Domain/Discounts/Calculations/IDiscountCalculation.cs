using Schikeria.Interfaces.Common;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Interfaces.Domain.Discounts.Calculations
{
    public interface IDiscountCalculation :
        IUniqueKey
    {
        public CalculationType CalculationType { get; }

        // TODO: KOntext moze?
        decimal Calculate(Discount discount, Order order);
    }
}
