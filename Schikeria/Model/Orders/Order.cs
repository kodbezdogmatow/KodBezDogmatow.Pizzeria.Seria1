namespace Schikeria.Model.Orders
{
    public class Order
    {
        public List<OrderItem> Items { get; set; } = [];

        public int TotalCount => Items.Sum(i => i.Count);
    }
}
