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
                (decimal?, decimal?) currencyDiscountResult = (null, null);

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
                     
                        currencyDiscountResult = GetDiscountCurrencyValue(
                            Names.VIP, Names.Loyality);

                        if (currencyDiscountResult.Item1 == null)
                        {
                            currencyDiscountResult = GetDiscountCurrencyValue(
                                Names.Student, Names.Saison);
                        }

                        if (currencyDiscountResult.Item1 != null)
                        {
                            sumDiscountValue = currencyDiscountResult.Item1.Value;

                            if (sumDiscountValue > 0.3m)
                            {
                                sumDiscountValue = 0.3m;
                            }
                        }
                    }
 
                    var percentagePriceValue = 1 - sumDiscountValue;

                    // Najpierw naliczamy rabaty procentowe, a pozniej rabaty cenowe
                    totalPrice *= percentagePriceValue;

                    if (currencyDiscountResult.Item1 != null)
                    {
                        totalPrice -= currencyDiscountResult.Item2!.Value;
                    }
                }

                return totalPrice;
            }
        }

        private (decimal?, decimal?) GetDiscountCurrencyValue(
            string percentDiscountName,
            string currencyDiscountName)
        {
            decimal? percentDiscountValue = null;
            decimal? currencyDiscountValue = null;
            if (CurrentDiscounts.Any(d => d.Name == percentDiscountName) &&
                CurrentDiscounts.Any(d => d.Name == currencyDiscountName))
            {
                percentDiscountValue = CurrentDiscounts
                    .First(d => d.Name == percentDiscountName).Value;

                currencyDiscountValue = CurrentDiscounts
                    .First(d => d.Name == currencyDiscountName).Value;
            }

            return (percentDiscountValue, currencyDiscountValue);
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
