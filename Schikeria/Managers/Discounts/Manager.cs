using Schikeria.Constants.Discounts;
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
                        Name = Names.Price100zl,
                        Value = 0.1m,
                        MinPrice = 100m
                    },
                    new Discount
                    {
                        Name = Names.Student,
                        Value = 0.15m
                    },
                    new Discount
                    {
                        Name = Names.Monday,
                        Value = 0.2m
                    },
                    new Discount
                    {
                        Name = Names.VIP,
                        Value = 0.2m
                    },
                    new GroupDiscount
                    {
                        Name = Names.Group2,
                        Value = 0.05m,
                        MinCount = 2
                    },
                    new GroupDiscount
                    {
                        Name = Names.Group3,
                        Value = 0.1m,
                        MinCount = 3
                    },
                    new GroupDiscount
                    {
                        Name = Names.Group5,
                        Value = 0.15m,
                        MinCount = 5
                    },
                ];
        }
    }
}
