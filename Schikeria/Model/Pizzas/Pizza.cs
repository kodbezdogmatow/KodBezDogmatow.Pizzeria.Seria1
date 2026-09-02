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
        public Discount? CurrentDiscount { get; set; }
        public int Count { get; set; } = 1;

        public decimal Price
        {
            get
            {
                var pizzaPrice = Sizes[CurrentSize];
                var toppingsPrice = Toppings.Sum(t => t.Price);
                var totalPrice = pizzaPrice + toppingsPrice;
                var isValid = false;

                if (CurrentDiscount != null)
                {
                    isValid = true;

                    var percentagePriceValue = 1m;
                    if (CurrentDiscount is PriceDiscount priceDiscount)
                    {
                        isValid = totalPrice >= priceDiscount.MinPrice;
                    }
                    else if (CurrentDiscount is GroupDiscount groupDiscount)
                    {
                        isValid =  Count >= groupDiscount.MinCount;
                    }

                    if (isValid)
                    {
                        percentagePriceValue = 1 - CurrentDiscount.Value;
                    }

                    totalPrice *= percentagePriceValue;
                }

                return totalPrice;
            }
        }
    }
}
