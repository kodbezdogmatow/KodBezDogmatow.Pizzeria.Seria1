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

        public decimal Price
        {
            get
            {
                var pizzaPrice = Sizes[CurrentSize];
                var toppingsPrice = Toppings.Sum(t => t.Price);
                var totalPrice = pizzaPrice + toppingsPrice;
                
                if (CurrentDiscount != null)
                {
                    var percentagePriceValue = 1m;
                    if (CurrentDiscount.MinPrice == null ||
                        totalPrice >= CurrentDiscount.MinPrice)
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
