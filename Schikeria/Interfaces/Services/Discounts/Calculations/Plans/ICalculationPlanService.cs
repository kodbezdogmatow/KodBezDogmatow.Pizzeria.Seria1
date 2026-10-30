using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Interfaces.Services.Discounts.Calculations.Plans
{
    public interface ICalculationPlanService
    {
        decimal Calculate(decimal price, CalculationPlan plan);
    }
}