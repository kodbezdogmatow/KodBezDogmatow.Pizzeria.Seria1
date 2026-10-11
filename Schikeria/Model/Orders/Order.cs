namespace Schikeria.Model.Orders
{
    public class Order
    {
        public List<OrderItem> Items { get; set; } = [];

        public int TotalCount => Items.Sum(i => i.Count);

        // TODO: Ta logike wyciagnac na zewnatrz na cene maja wplyw rabat, a pozniej
        // napewno inne jeszcze czynniki
        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);
    }
}
