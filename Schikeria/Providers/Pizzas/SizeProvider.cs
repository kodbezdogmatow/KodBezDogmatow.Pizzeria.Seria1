using Schikeria.Interfaces.Providers.Pizzas;
using Schikeria.Model.Pizzas;

namespace Schikeria.Providers.Pizzas
{
    public class SizeProvider : 
        ISizeProvider
    {
        public List<Sizes> GetAll()
        {
            return Enum
                .GetValues<Sizes>()
                .Where(s => s != Sizes.None)
                .ToList();
        }
    }
}
