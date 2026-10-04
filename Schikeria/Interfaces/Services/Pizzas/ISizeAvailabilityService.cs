using Schikeria.Model.Pizzas;

namespace Schikeria.Interfaces.Services.Pizzas
{
    public interface ISizeAvailabilityService
    {
        bool Validate(string name, Sizes size);
    }
}