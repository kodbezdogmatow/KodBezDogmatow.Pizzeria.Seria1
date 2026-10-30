using Schikeria.Interfaces.Services.Discounts.Calculations.Groups;
using Schikeria.Model.Discounts;
using Schikeria.Model.Discounts.Calculations;

namespace Schikeria.Services.Discounts.Calculations.Groups
{
    // ! Jak sie rozrosnie to rozdzielic wg SRP, na ta chwile jest ta
    // ! klasa przewidziana tylko dla add i remove, ktore nie maja duzo logiki
    public class ManagementService : 
        IManagementService
    {
        public void Add(CalculationGroup group, Discount discount)
        {
            // TODO: Sprawdzanie duplikatow?
            if (group.CalculationType != discount.CalculationType)
            {
                throw new ArgumentException("Rabat ma inny typ naliczen niz grupa. Dodanie jest nie mozliwe.");
            }

            group.Discounts.Add(discount);
        }

        public void Remove(CalculationGroup group, Discount discount)
        {
            if (!group.Discounts.Remove(discount))
            {
                throw new ArgumentException($"Rabat '{discount.Name}' nie zostal usuniety z grupy");
            }
        }
    }
}
