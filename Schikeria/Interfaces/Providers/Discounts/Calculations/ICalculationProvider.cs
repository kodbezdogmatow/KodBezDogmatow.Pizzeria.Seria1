using Schikeria.Interfaces.Domain.Discounts.Calculations;

namespace Schikeria.Interfaces.Providers.Discounts.Calculations
{
    public interface ICalculationProvider
    {
        List<IDiscountCalculation> Get();
    }
}