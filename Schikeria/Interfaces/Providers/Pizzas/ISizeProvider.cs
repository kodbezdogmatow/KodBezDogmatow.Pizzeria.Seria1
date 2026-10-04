using Schikeria.Model.Pizzas;

namespace Schikeria.Interfaces.Providers.Pizzas
{
    public interface ISizeProvider
    {
        List<Sizes> GetAll();
    }
}