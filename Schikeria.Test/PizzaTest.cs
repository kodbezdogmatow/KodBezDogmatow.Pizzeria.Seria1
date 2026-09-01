using Schikeria.Model.Pizzas;
using Schikeria.Model.Toppings;

namespace Schikeria.Test
{
    public class PizzaTest
    {
        [Fact]
        public void Test_Price()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(33, price);
            });
        }
    }
}
