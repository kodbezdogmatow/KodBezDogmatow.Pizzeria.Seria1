namespace Schikeria.Model.Discounts
{
    public class GroupDiscount :
        Discount
    {
        public required int MinCount { get; set; }
    }
}
