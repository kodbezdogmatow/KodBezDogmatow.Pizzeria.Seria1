using Schikeria.Model.Pizzas;

namespace Schikeria.Providers.Pizzas
{
    public class Provider
    {       
        public List<Pizza> Get()
        {
            var margherita = new Pizza
            {
                Name = Names.Margherita,
            };

            margherita.Sizes.Add(Sizes.Small, 27.5m);
            margherita.Sizes.Add(Sizes.Medium, 30);
            margherita.Sizes.Add(Sizes.Large, 32.7m);
            margherita.Sizes.Add(Sizes.XL, 40.2m);
            margherita.Sizes.Add(Sizes.XXL, 56);

            var salami = new Pizza
            {
                Name = Names.Salami,
            };

            salami.Sizes.Add(Sizes.Small, 31.5m);
            salami.Sizes.Add(Sizes.Medium, 33.5m);
            salami.Sizes.Add(Sizes.Large, 35.7m);
            salami.Sizes.Add(Sizes.XL, 39.4m);
            salami.Sizes.Add(Sizes.XXL, 75);

            var pepperoni = new Pizza
            {
                Name = Names.Pepperoni,
            };

            pepperoni.Sizes.Add(Sizes.Small, 30.5m);
            pepperoni.Sizes.Add(Sizes.Medium, 31.5m);
            pepperoni.Sizes.Add(Sizes.Large, 34.7m);
            pepperoni.Sizes.Add(Sizes.XL, 35.4m);
            pepperoni.Sizes.Add(Sizes.XXL, 58.5m);

            var hawajska = new Pizza
            {
                Name = Names.Hawajska,
            };

            hawajska.Sizes.Add(Sizes.Small, 25);
            hawajska.Sizes.Add(Sizes.Medium, 27.5m);
            hawajska.Sizes.Add(Sizes.Large, 29);
            hawajska.Sizes.Add(Sizes.XL, 32.5m);
            hawajska.Sizes.Add(Sizes.XXL, 42.1m);

            var diavola = new Pizza
            {
                Name = Names.Diavola,
            };

            diavola.Sizes.Add(Sizes.Small, 35);
            diavola.Sizes.Add(Sizes.Medium, 38.5m);
            diavola.Sizes.Add(Sizes.Large, 41.3m);
            diavola.Sizes.Add(Sizes.XL, 45m);
            diavola.Sizes.Add(Sizes.XXL, 72m);

            var capricciosa = new Pizza
            {
                Name = Names.Capricciosa,
            };

            capricciosa.Sizes.Add(Sizes.Small, 39);
            capricciosa.Sizes.Add(Sizes.Medium, 41.5m);
            capricciosa.Sizes.Add(Sizes.Large, 44.3m);
            capricciosa.Sizes.Add(Sizes.XL, 49.3m);
            capricciosa.Sizes.Add(Sizes.XXL, 65m);

            var rukola = new Pizza
            {
                Name = Names.Rukola,
            };

            rukola.Sizes.Add(Sizes.Small, 21);
            rukola.Sizes.Add(Sizes.Medium, 22.5m);
            rukola.Sizes.Add(Sizes.Large, 24.3m);
            rukola.Sizes.Add(Sizes.XL, 26.3m);
            rukola.Sizes.Add(Sizes.XXL, 29.99m);

            return [
                margherita,
                salami,
                pepperoni,
                hawajska,
                diavola,
                capricciosa,
                rukola
            ];
        }
    }
}
