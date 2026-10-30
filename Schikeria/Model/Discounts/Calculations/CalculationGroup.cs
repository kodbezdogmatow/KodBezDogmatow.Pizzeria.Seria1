namespace Schikeria.Model.Discounts.Calculations
{
    public class CalculationGroup
    {
        public Guid Id { get; } = Guid.NewGuid();
        public CalculationType CalculationType { get; set; }
        public int Priority { get; set; }
        public List<Discount> Discounts { get; set; } = [];
    }
}
