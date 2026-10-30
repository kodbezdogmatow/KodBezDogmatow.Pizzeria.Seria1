using Schikeria.Interfaces.Providers.Services.Discounts.Calculations;
using Schikeria.Interfaces.Services.Discounts.Calculations.Plans;
using Schikeria.Model.Discounts.Calculations;
using Schikeria.Providers.Services.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Plans
{
    public class CalculationPlanService : 
        ICalculationPlanService
    {
        private readonly ICalculationGroupServiceProvider _calculationGroupServiceProvider = new CalculationGroupServiceProvider();

        public decimal Calculate(decimal price, CalculationPlan plan)
        {
            var currentPrice = price;
            var calculationGroupServices = _calculationGroupServiceProvider.Get();
            var groups = plan.Groups
                .OrderBy(g => g.Priority)
                .ToList();
            foreach (var group in groups)
            {
                currentPrice = calculationGroupServices
                    .First(s => s.CalculationType == group.CalculationType)
                    .Calculate(currentPrice, group);
            }

            return currentPrice;
        }
    }
}
