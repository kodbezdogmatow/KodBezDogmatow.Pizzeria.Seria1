using Schikeria.Interfaces.Services.Discounts.Calculations.Plans;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Plans
{
    // ! Jak sie rozrosnie to rozdzielic wg SRP, na ta chwile jest ta
    // ! klasa przewidziana tylko dla add i remove, ktore nie maja duzo logiki
    public class ManagementService : 
        IManagementService
    {
        private readonly IPriorityAssingmentService _priorityAssingmentService = new PriorityAssingmentService();

        // TODO: Tworzenie grupy? Podczas piwerszego dodania rabatu? Kto jest za to odpowiedzialny?
        public void Add(CalculationPlan plan, CalculationGroup group)
        {
            // TODO: Sprawdzanie duplikatow?
            if (plan.Groups.Any(g => g.Id == group.Id))
            {
                throw new ArgumentException("Grupa jest juz dodana do planu naliczen.");
            }

            group.Priority = plan.Groups.Count;

            _priorityAssingmentService.AdjustPriority(plan);

            plan.Groups.Add(group);
        }

        public void Remove(CalculationPlan plan, CalculationGroup group)
        {
            if (!plan.Groups.Remove(group))
            {
                throw new ArgumentException($"Grupa nie zostal usuniety z planu");
            }

            _priorityAssingmentService.AdjustPriority(plan);
        }
    }
}
