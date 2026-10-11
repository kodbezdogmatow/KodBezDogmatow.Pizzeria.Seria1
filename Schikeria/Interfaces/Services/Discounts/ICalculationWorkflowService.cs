using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Interfaces.Services.Discounts
{
    public interface ICalculationWorkflowService
    {
        decimal Calculate(Discount discount, Order order);
    }
}