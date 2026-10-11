using Schikeria.Interfaces.Services.Discounts;
using Schikeria.Interfaces.Services.Discounts.Calculations;
using Schikeria.Interfaces.Services.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;

namespace Schikeria.Services.Discounts
{
    public class CalculationWorkflowService :
        ICalculationWorkflowService
    {
        private readonly IConditionService _conditionService;
        private readonly ICalculationService _calculationService;

        public CalculationWorkflowService(
            IConditionService conditionService,
            ICalculationService calculationService)
        {
            _conditionService = conditionService;
            _calculationService = calculationService;
        }

        // TODO: Czy kolejnosc naliczania rabatow ma znaczenie, czy cala sume naliczamy?
        public decimal Calculate(
            Discount discount,
            Order order)
        {
            var price = order.TotalPrice;
            if (_conditionService.IsSatisfied(discount, order))
            {
                price = _calculationService.Calculate(discount, order);
            }

            return price;
        }
    }
}
