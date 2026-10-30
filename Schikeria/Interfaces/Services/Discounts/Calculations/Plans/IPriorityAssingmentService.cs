using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Interfaces.Services.Discounts.Calculations.Plans
{
    public interface IPriorityAssingmentService
    {
        void AdjustPriority(CalculationPlan plan);
    }
}