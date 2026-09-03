using Schikeria.Constants.Discounts;
using Schikeria.Model.Discounts;
using Schikeria.Model.Toppings;

namespace Schikeria.Model.Pizzas
{
    public class Pizza
    {
        // REFACTOR: Nie intuicyjne, ciezkie do "zarzadzania"
        public Dictionary<Sizes, decimal> Sizes { get; set; } = [];
        public required string Name { get; set; }
        public List<Topping> Toppings { get; set; } = [];

        public Sizes CurrentSize { get; set; }
        public List<Discount> CurrentDiscounts { get; set; } = [];
        public int Count { get; set; } = 1;

        public decimal Price
        {
            get
            {
                var pizzaPrice = Sizes[CurrentSize];
                var toppingsPrice = Toppings.Sum(t => t.Price);
                var totalPrice = pizzaPrice + toppingsPrice;

                if (CurrentDiscounts.Count > 0)
                {
                    var sumDiscountValue = 0m;

                    // 2. Niektóre rabaty można łączyć.

                    //Przykładowo:

                    //student + poniedziałek → można połączyć,
                    //VIP +poniedziałek → można połączyć,

                    //rabat grupowy + VIP → można.

                    //rabat grupowy + inny niz vip → zawsze grupowy,

                    //jesli wiele rabatow i kazda z powyzszych regul nie zachodzi, to tylko rabat grupowy
                    //jesli wiele rabatow i kazda z powyzszych regul nie zachodzi, zaden grupowy, to najwyzszy rabat

                    //Dochodzi też zasada:

                    //maksymalny łączny rabat to 30%.

                    // Sprawdzanie kombinacji
                    var maxGroupDiscount = CurrentDiscounts
                        .OfType<GroupDiscount>()
                        .OrderByDescending(d => d.Value)
                        .FirstOrDefault();

                    if (maxGroupDiscount  != null)
                    {
                        var vipDiscount = CurrentDiscounts
                            .FirstOrDefault(m => m.Name == Names.VIP);

                        if (vipDiscount != null)
                        {
                            sumDiscountValue = maxGroupDiscount.Value + vipDiscount.Value;
                        }
                        else
                        {
                            sumDiscountValue = maxGroupDiscount.Value;
                        }
                    }
                    else
                    {
                        //student + poniedziałek → można połączyć,
                        //VIP + poniedziałek → można połączyć,
                        var mondayDiscount = CurrentDiscounts
                            .FirstOrDefault(m => m.Name == Names.Monday);
                        if (mondayDiscount != null)
                        {
                            var studentDiscount = CurrentDiscounts
                                .FirstOrDefault(m => m.Name == Names.Student);
                            var vipDiscount = CurrentDiscounts
                                .FirstOrDefault(m => m.Name == Names.VIP);

                            if (studentDiscount != null && vipDiscount != null)
                            {
                                sumDiscountValue = studentDiscount.Value > vipDiscount.Value
                                    ? studentDiscount.Value
                                    : vipDiscount.Value;
                            }
                            else if (studentDiscount != null)
                            {
                                sumDiscountValue = studentDiscount.Value;
                            }
                            else if (vipDiscount != null)
                            {
                                sumDiscountValue = vipDiscount.Value;
                            }
                        }
                        else
                        {
                            sumDiscountValue = CurrentDiscounts.Max(m => m.Value);
                        }
                    }

                    //var percentagePriceValue = 1m;
                    //if (CurrentDiscounts is PriceDiscount priceDiscount)
                    //{
                    //    isValid = totalPrice >= priceDiscount.MinPrice;
                    //}
                    //else if (CurrentDiscounts is GroupDiscount groupDiscount)
                    //{
                    //    isValid =  Count >= groupDiscount.MinCount;
                    //}

                    //if (isValid)
                    //{
                        var percentagePriceValue = 1 - sumDiscountValue;
                    //}

                    totalPrice *= percentagePriceValue;
                }

                return totalPrice;
            }
        }
    }
}
