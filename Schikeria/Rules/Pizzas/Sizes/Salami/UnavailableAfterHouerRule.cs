using Schikeria.Interfaces.Rules.Pizzas.Salami;

namespace Schikeria.Rules.Pizzas.Sizes.Salami
{
    public class UnavailableAfterHouerRule :
        IUnavailableAfterHouerRule
    {
        public bool IsSatisfied() => DateTime.Now.Hour > 20;
    }
}
