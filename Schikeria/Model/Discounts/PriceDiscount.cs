namespace Schikeria.Model.Discounts
{
    public class PriceDiscount : 
        Discount
    {
        public required decimal MinPrice { get; set; }
    }
}
