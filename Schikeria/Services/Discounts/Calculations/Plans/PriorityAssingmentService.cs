using Schikeria.Interfaces.Services.Discounts.Calculations.Plans;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Plans
{
    public class PriorityAssingmentService : 
        IPriorityAssingmentService
    {
        public void AdjustPriority(CalculationPlan plan)
        {
            var areDuplicates = plan.Groups
                .GroupBy(g => g.Priority)
                .Count(g => g.Count() > 1) > 0;

            if (areDuplicates)
            {
                throw new ArgumentException("Priorytet nie moze zostan ustawiony, poniewaz wystepuja grupy z tym samym priorytetem wielokrotnie");
            }

            var currentPriority = 0;
            plan.Groups
                .OrderBy(g => g.Priority)
                .ToList()
                .ForEach(g =>
                {
                    g.Priority = currentPriority;
                    currentPriority += 1;
                });
        }
    }
}
