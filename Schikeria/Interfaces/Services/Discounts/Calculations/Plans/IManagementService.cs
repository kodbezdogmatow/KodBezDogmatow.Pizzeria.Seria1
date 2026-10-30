using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Interfaces.Services.Discounts.Calculations.Plans
{
    public interface IManagementService
    {
        void Add(CalculationPlan plan, CalculationGroup group);
        void Remove(CalculationPlan plan, CalculationGroup group);
    }
}