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

                            if (sumDiscountValue > 0.3m)
                            {
                                sumDiscountValue = 0.3m;
                            }
                        }
                        else
                        {
                            sumDiscountValue = GetMaxDiscountValue(totalPrice);
                        }
                    }
                    else
                    {
                        sumDiscountValue = GetDiscountPercentValue(totalPrice);

                        // lojalnościowy + Vip
                        // Rabat sezonowy + Student
                        var sumDiscountCurrencyValue = GetDiscountCurrencyValue(
                            Names.Loyality, Names.VIP);

                        if (sumDiscountCurrencyValue == null)
                        {
                            sumDiscountCurrencyValue = GetDiscountCurrencyValue(
                                Names.Saison, Names.Student);
                        }

                        if (sumDiscountCurrencyValue != null)
                        {
                            sumDiscountValue = sumDiscountCurrencyValue.Value;

                            if (sumDiscountValue > 0.3m)
                            {
                                sumDiscountValue = 0.3m;
                            }
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

        private decimal? GetDiscountCurrencyValue(
            string firstDiscountName,
            string secondDiscountName)
        {
            decimal? sumDiscountValue = null;
            if (CurrentDiscounts.Any(d => d.Name == firstDiscountName) &&
                CurrentDiscounts.Any(d => d.Name == secondDiscountName))
            {
                sumDiscountValue = CurrentDiscounts
                    .First(d => d.Name == Names.Loyality).Value +
                    CurrentDiscounts
                    .First(d => d.Name == Names.VIP).Value;
            }

            return sumDiscountValue;
        }

        private decimal GetDiscountPercentValue(decimal totalPrice)
        {
            decimal sumDiscountValue;
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

                    if (sumDiscountValue > 0.3m)
                    {
                        sumDiscountValue = 0.3m;
                    }
                }
                else if (studentDiscount != null)
                {
                    sumDiscountValue = studentDiscount.Value + mondayDiscount.Value;

                    if (sumDiscountValue > 0.3m)
                    {
                        sumDiscountValue = 0.3m;
                    }
                }
                else if (vipDiscount != null)
                {
                    sumDiscountValue = vipDiscount.Value + mondayDiscount.Value;

                    if (sumDiscountValue > 0.3m)
                    {
                        sumDiscountValue = 0.3m;
                    }
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

            return sumDiscountValue;
        }

        private decimal GetMaxDiscountValue(decimal totalPrice)
        {
            var discountValue = 0m;

            var groupDiscounts = CurrentDiscounts
                .OfType<GroupDiscount>()
                .ToList();

            var maxGroupDiscount = groupDiscounts
                .Where(gd => Count >= gd.MinCount)
                .OrderByDescending(d => d.Value)
                .FirstOrDefault();

            if (maxGroupDiscount != null)
            {
                return maxGroupDiscount.Value;
            }

            var sortedDiscounts = CurrentDiscounts
                .Except(groupDiscounts)
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
                    else
                    {
                        discountValue = discount.Value;
                        break;
                    }
                }
            }

            return discountValue;
        }
    }
}
