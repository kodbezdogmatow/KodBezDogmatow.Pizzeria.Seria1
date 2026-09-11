namespace Schikeria.Model.Discounts
{
    // TODO: 2 Rabaty Grupowy i Ceny min. maja dodatkowa logike sprawdzenia czy mozna je naliczyc
    public class GroupDiscount :
        Discount
    {
        public required int MinCount { get; set; }
    }
}
