using Schikeria.Interfaces.Services.Discounts.Calculations.Groups;
using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Groups
{
    public abstract class CalculationGroupServiceBase : 
        ICalculationGroupService
    {
        public abstract CalculationType CalculationType { get; }

        public decimal Calculate(decimal price, CalculationGroup calculationGroup)
        {
            if (calculationGroup.CalculationType != CalculationType)
            {
                throw new ArgumentException($"Oczekiwany jest typ naliczenia '{calculationGroup.CalculationType}'");
            }

            // TODO: Walidacja
            var discountSum = calculationGroup.Discounts
                .Sum(d => d.Value);

            if (discountSum == 0)
            {
                return price;
            }

            return SpecifyCalculate(price, calculationGroup);
        }

        protected abstract decimal SpecifyCalculate(decimal price, CalculationGroup calculationGroup);
    }
}
