using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Interfaces.Services.Discounts.Calculations.Groups
{
    public interface IManagementService
    {
        void Add(CalculationGroup group, Discount discount);
        void Remove(CalculationGroup group, Discount discount);
    }
}