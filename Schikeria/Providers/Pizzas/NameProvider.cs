using Schikeria.Constants.Pizzas;
using Schikeria.Interfaces.Providers.Pizzas;

namespace Schikeria.Providers.Pizzas
{
    public class NameProvider : 
        INameProvider
    {
        public List<string> GetAll()
        {
            // TODO: Zcentralizowac to moze?
            return typeof(Names)
                .GetFields()
                .Where(x => x.IsLiteral && !x.IsInitOnly)
                // Tu bedzie zawsze wartosc zwrocona dlatego operator ! jest uzasadniony
                .Select(x => (string)x.GetValue(null)!)
                .ToList();
        }
    }
}
