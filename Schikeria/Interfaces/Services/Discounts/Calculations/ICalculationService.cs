using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Interfaces.Services.Discounts.Calculations
{
    public interface ICalculationService
    {
        decimal Calculate(Discount discount, Order order);
    }
}