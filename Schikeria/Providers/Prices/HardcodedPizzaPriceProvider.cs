using Schikeria.Constants.Pizzas;
using Schikeria.Guards;
using Schikeria.Interfaces.Providers.Prices;
using Schikeria.Model.Pizzas;

namespace Schikeria.Providers.Prices
{
    // TECHDEBT: Tymczasowe rozwiazanie dla tego jednego klienta. Po refaktoryzacji
    // bedzie wiecej kandydatow, dlatego dane cen nie beda zahardkodowane w kodzie.
    // Beda wczytywane z jakiegos zrodla danych np. bazy danych.
    // W tym momencie celem jest udostepnienie funkcjonalosci ktora jest elastyczna na
    // dynamiczne zmiany i tym jest to rozwiazanie. Jesli juz ta Legacy-Logika zniknie
    // to z nia ten provider i reszta pozostaje tj. Factory, Serwis. Ewentualnie zniknie Factory
    // ale ciagle rozwiazanie pozostaje dynamiczne i elastyczne na zmiany.
    public class HardcodedPizzaPriceProvider : 
        // TODO: Nazwa bardziej ogolna
        IHardcodedPizzaPriceProvider
    {
        public decimal Get(string pizzaName, Sizes size)
        {
            decimal? price = null;

            if (pizzaName == Names.Margherita)
            {
                price = GetPrcieForMargahrita(size);
            }
            else if (pizzaName == Names.Salami)
            {
                price = GetPrcieForSalami(size);
            }
            else if (pizzaName == Names.Pepperoni)
            {
                price = GetPrcieForPepperoni(size);
            }
            else if (pizzaName == Names.Hawajska)
            {
                price = GetPrcieForHawajska(size);
            }
            else if (pizzaName == Names.Diavola)
            {
                price = GetPrcieForDiavola(size);
            }
            else if (pizzaName == Names.Capricciosa)
            {
                price = GetPrcieForCapricciosa(size);
            }
            else if (pizzaName == Names.Rukola)
            {
                price = GetPrcieForRukola(size);
            }
            else if (pizzaName == Names.Weganska)
            {
                price = GetPrcieForWeganska(size);
            }

            return NotNullGuard.Against(price);
        }

        private decimal? GetPrcieForMargahrita(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 27.5m;
                    break;
                case Sizes.Medium:
                    price = 30;
                    break;
                case Sizes.Large:
                    price = 32.7m;
                    break;
                case Sizes.XL:
                    price = 40.2m;
                    break;
                case Sizes.XXL:
                    price = 56m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForSalami(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 31.5m;
                    break;
                case Sizes.Medium:
                    price = 33.5m;
                    break;
                case Sizes.Large:
                    price = 35.7m;
                    break;
                case Sizes.XL:
                    price = 39.4m;
                    break;
                case Sizes.XXL:
                    price = 75m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForPepperoni(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 30.5m;
                    break;
                case Sizes.Medium:
                    price = 31.5m;
                    break;
                case Sizes.Large:
                    price = 34.7m;
                    break;
                case Sizes.XL:
                    price = 35.4m;
                    break;
                case Sizes.XXL:
                    price = 58.5m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForHawajska(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 25;
                    break;
                case Sizes.Medium:
                    price = 27.5m;
                    break;
                case Sizes.Large:
                    price = 29;
                    break;
                case Sizes.XL:
                    price = 32.5m;
                    break;
                case Sizes.XXL:
                    price = 42.1m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForDiavola(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 35m;
                    break;
                case Sizes.Medium:
                    price = 38.5m;
                    break;
                case Sizes.Large:
                    price = 41.3m;
                    break;
                case Sizes.XL:
                    price = 45m;
                    break;
                case Sizes.XXL:
                    price = 72m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForCapricciosa(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 39;
                    break;
                case Sizes.Medium:
                    price = 41.5m;
                    break;
                case Sizes.Large:
                    price = 44.3m;
                    break;
                case Sizes.XL:
                    price = 49.3m;
                    break;
                case Sizes.XXL:
                    price = 65m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForRukola(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 18;
                    break;
                case Sizes.Medium:
                    price = 21.5m;
                    break;
                case Sizes.Large:
                    price = 23.6m;
                    break;
                case Sizes.XL:
                    price = 27.8m;
                    break;
                case Sizes.XXL:
                    price = 30m;
                    break;
            }

            return price;
        }

        private decimal? GetPrcieForWeganska(Sizes size)
        {
            decimal? price = null;

            switch (size)
            {
                case Sizes.Small:
                    price = 21.5m;
                    break;
                case Sizes.Medium:
                    price = 23.8m;
                    break;
                case Sizes.Large:
                    price = 31.7m;
                    break;
                case Sizes.XL:
                    price = 36.65m;
                    break;
                case Sizes.XXL:
                    price = 39.99m;
                    break;
            }

            return price;
        }
    }
}
