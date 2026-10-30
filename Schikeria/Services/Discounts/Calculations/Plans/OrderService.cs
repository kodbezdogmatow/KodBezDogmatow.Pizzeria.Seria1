using Schikeria.Interfaces.Services.Discounts.Calculations.Plans;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Plans
{
    // TODO: Logike przenoszenia do gory i do dolu nalezy scentralizowac
    // TODO: Logika przenoszenia w dol i do gory jest w duzej czesci identyczna - scntralizowac
    public class OrderService
    {
        private readonly IPriorityAssingmentService _priorityAssingmentService = new PriorityAssingmentService();

        public void MoveUp(CalculationPlan plan, CalculationGroup calculationGroup)
        {           
            var groupIndex = plan.Groups.IndexOf(calculationGroup);
            if (groupIndex == -1)
            {
                throw new ArgumentException("Grupa nie moze zostac przeniesiona, bo nie nalezy do planu");
            }

            if (groupIndex == 0)
            {
                return;
            }

            var previouseGroupIndex = groupIndex - 1;
            var previouseGroup = plan.Groups[previouseGroupIndex];
            var groupPriority = calculationGroup.Priority;
            calculationGroup.Priority = previouseGroup.Priority;
            previouseGroup.Priority = groupPriority;

            // Wywolanie, by zapewnic spojnosc priorytetu(zapezpieczenie)
            _priorityAssingmentService.AdjustPriority(plan);
        }

        public void MoveDown(CalculationPlan plan, CalculationGroup calculationGroup)
        {
            var groupIndex = plan.Groups.IndexOf(calculationGroup);
            if (groupIndex == -1)
            {
                throw new ArgumentException("Grupa nie moze zostac przeniesiona, bo nie nalezy do planu");
            }

            var lastIndex = plan.Groups.Count - 1;

            if (groupIndex == lastIndex)
            {
                return;
            }

            var nextGroupIndex = groupIndex + 1;
            var nextGroup = plan.Groups[nextGroupIndex];
            var groupPriority = calculationGroup.Priority;
            calculationGroup.Priority = nextGroup.Priority;
            nextGroup.Priority = groupPriority;

            // Wywolanie, by zapewnic spojnosc priorytetu(zapezpieczenie)
            _priorityAssingmentService.AdjustPriority(plan);
        }
    }
}
