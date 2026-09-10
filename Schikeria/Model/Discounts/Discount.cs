namespace Schikeria.Model.Discounts
{
    public class Discount
    {
        public required string Name { get; set; }
        public required decimal Value { get; set; }

        // 1. ValueType: % albo zl
        // 2. Nowa klasa (pusta)
    }

    //  1. rabaty kwoty:
    //      - Rabat lojalnościowy — 15zl
    //      - Rabat sezonowy — 25 zl
    //      - Rabat promocyjny — 30 zl

    //  2. Kombinacje
    //      - Rabat lojalnościowy +Vip
    //      - Rabat sezonowy + Student

    //  3. Najpierw naliczamy rabaty procentowe, a pozniej rabaty cenowe
}
