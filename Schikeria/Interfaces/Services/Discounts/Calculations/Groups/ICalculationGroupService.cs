using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Interfaces.Services.Discounts.Calculations.Groups
{
    public interface ICalculationGroupService
    {
        CalculationType CalculationType { get; }

        decimal Calculate(decimal price, CalculationGroup calculationGroup);
    }
}