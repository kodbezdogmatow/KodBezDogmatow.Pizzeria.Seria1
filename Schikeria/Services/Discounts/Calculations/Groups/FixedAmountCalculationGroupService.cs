using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Groups
{
    public class FixedAmountCalculationGroupService :
        CalculationGroupServiceBase
    {
        public override CalculationType CalculationType => CalculationType.FixedAmount;

        protected override decimal SpecifyCalculate(
            decimal price,
            CalculationGroup calculationGroup)
        {
            var discountSum = calculationGroup.Discounts
                .Sum(d => d.Value);

            if (discountSum > price)
            {
                return 0;
            }

            return price - discountSum;
        }
    }
}
