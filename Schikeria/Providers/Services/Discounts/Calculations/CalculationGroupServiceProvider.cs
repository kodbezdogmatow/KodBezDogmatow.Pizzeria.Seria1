using Schikeria.Interfaces.Providers.Services.Discounts.Calculations;
using Schikeria.Interfaces.Services.Discounts.Calculations.Groups;
using Schikeria.Providers.Bases;

namespace Schikeria.Providers.Services.Discounts.Calculations
{
    public class CalculationGroupServiceProvider :
        ImplementationProvider, 
        ICalculationGroupServiceProvider
    {
        public List<ICalculationGroupService> Get()
        {
            return GetImplementations<ICalculationGroupService>();
        }
    }
}
