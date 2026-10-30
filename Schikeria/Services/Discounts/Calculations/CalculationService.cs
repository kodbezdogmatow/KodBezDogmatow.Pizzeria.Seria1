using Schikeria.Interfaces.Common;
using Schikeria.Interfaces.Providers.Discounts.Calculations;
using Schikeria.Interfaces.Services.Discounts.Calculations;
using Schikeria.Interfaces.Services.Duplications;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Services.Discounts.Calculations
{
    // TODO: DBO - czy bedzie jeszcze potrzebny?
    public class CalculationService :
        ICalculationService
    {
        private readonly ICalculationProvider _calculationProvider;
        private readonly IDuplicationService _duplicationService;

        public CalculationService(
            ICalculationProvider calculationProvider,
            IDuplicationService duplicationService)
        {
            _calculationProvider = calculationProvider;
            _duplicationService = duplicationService;
        }

        public decimal Calculate(
            Discount discount,
            Order order)
        {

            var calculations = _calculationProvider
                .Get();

            var duplicationResult = _duplicationService.Get(
                calculations.ConvertAll<IUniqueKey>(c => c));

            if (duplicationResult.Count > 0)
            {
                // TODO: Jak bedzie UI to precyzyjna wiadomosc
                throw new InvalidOperationException($"Konfiguracja naliczania rabatow jest nieprawidlowa. Powtorzen '{duplicationResult.Count}'");
            }

            var calculation = calculations
                .FirstOrDefault(c => c.CalculationType == discount.CalculationType);

            if (calculation != null)
            {
                return calculation.Calculate(discount, order);
            }

            throw new InvalidOperationException($"Typ naliczania rabatu '{discount.CalculationType} jest nie wspierany.'");
        }
    }
}
