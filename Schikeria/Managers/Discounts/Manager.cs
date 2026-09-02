using Schikeria.Model.Discounts;

namespace Schikeria.Managers.Discounts
{
    public class Manager
    {
        private readonly List<Discount> _discounts;

        public Manager()
        {
            _discounts = [
                    new PriceDiscount
                    {
                        Name = "Powyżej 100 zł",
                        Value = 0.1m,
                        MinPrice = 100m
                    },
                    new Discount
                    {
                        Name = "Dla Studentów",
                        Value = 0.15m
                    },
                    new Discount
                    {
                        Name = "W Poniedziałek",
                        Value = 0.2m
                    },
                    new Discount
                    {
                        Name = "VIP",
                        Value = 0.2m
                    },
                ];
        }
    }
}
