namespace Schikeria.Model.Discounts
{
    public class Discount
    {
        public required string Name { get; set; }
        public required decimal Value { get; set; }
        public decimal? MinPrice { get; set; }
    }
}
