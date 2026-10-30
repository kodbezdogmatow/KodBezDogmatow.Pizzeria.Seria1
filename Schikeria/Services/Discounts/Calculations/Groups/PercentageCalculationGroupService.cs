using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Groups
{
    public class PercentageCalculationGroupService :
        CalculationGroupServiceBase
    {
        public override CalculationType CalculationType => CalculationType.Percentage;

        protected override decimal SpecifyCalculate(
            decimal price, 
            CalculationGroup calculationGroup)
        {
            var discountSum = calculationGroup.Discounts
                .Sum(d => d.Value);

            if (discountSum > 1)
            {
                return 0;
            }

            return price * (1 - discountSum);
        }
    }
}
