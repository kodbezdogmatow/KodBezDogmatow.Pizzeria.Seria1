using Schikeria.Interfaces.Domain.Discounts.Calculations;
using Schikeria.Interfaces.Providers.Discounts.Calculations;
using Schikeria.Providers.Bases;

namespace Schikeria.Providers.Discounts.Calculations
{
    public class CalculationProvider :
        ImplementationProvider, 
        ICalculationProvider
    {
        public List<IDiscountCalculation> Get()
        {
            return GetImplementations<IDiscountCalculation>();
        }
    }
}
