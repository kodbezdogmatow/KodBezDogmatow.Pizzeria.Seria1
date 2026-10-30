using Schikeria.Interfaces.Services.Discounts.Calculations.Groups;

namespace Schikeria.Interfaces.Providers.Services.Discounts.Calculations
{
    public interface ICalculationGroupServiceProvider
    {
        List<ICalculationGroupService> Get();
    }
}