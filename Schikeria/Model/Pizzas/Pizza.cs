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

                    // Sprawdzanie kombinacji
                    var maxGroupDiscount = CurrentDiscounts
                        .OfType<GroupDiscount>()
                        .OrderByDescending(d => d.Value)
                        .FirstOrDefault();

                    if (maxGroupDiscount != null)
                    {
                        var vipDiscount = CurrentDiscounts
                            .FirstOrDefault(m => m.Name == Names.VIP);

                        if (vipDiscount != null)
                        {
                            sumDiscountValue = maxGroupDiscount.Value + vipDiscount.Value;
                        }
                        else
                        {
                            sumDiscountValue = GetMaxDiscountValue(totalPrice);
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

                                sumDiscountValue += mondayDiscount.Value;
                            }
                            else if (studentDiscount != null)
                            {
                                sumDiscountValue = studentDiscount.Value + mondayDiscount.Value;
                            }
                            else if (vipDiscount != null)
                            {
                                sumDiscountValue = vipDiscount.Value + mondayDiscount.Value;
                            }
                            else
                            {
                                sumDiscountValue = GetMaxDiscountValue(totalPrice);
                            }
                        }
                        else
                        {
                            sumDiscountValue = GetMaxDiscountValue(totalPrice);
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

        private decimal GetMaxDiscountValue(decimal totalPrice)
        {
            var discountValue = 0m;
            var sortedDiscounts = CurrentDiscounts
                .OrderByDescending(d => d.Value)
                .ToList();

            foreach (var discount in sortedDiscounts)
            {
                if (discount != null)
                {
                    if (discount is PriceDiscount priceDiscount)
                    {
                        if (totalPrice >= priceDiscount.MinPrice)
                        {
                            discountValue = priceDiscount.Value;
                            break;
                        }
                    }
                    else if (discount is GroupDiscount groupDiscount)
                    {
                        if (Count >= groupDiscount.MinCount)
                        {
                            discountValue = groupDiscount.Value;
                            break;
                        }
                    }
                    else
                    {
                        // TODO: jesli grupowy w liscie, to wez ten rabat
                        discountValue = discount.Value;
                        break;
                    }
                }
            }

            return discountValue;
        }
    }
}
