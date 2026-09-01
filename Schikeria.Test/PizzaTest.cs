using Schikeria.Model.Discounts;
using Schikeria.Model.Pizzas;
using Schikeria.Model.Toppings;

namespace Schikeria.Test
{
    public class PizzaTest
    {
        [Fact]
        public void Calculate_Price_WithoutDiscount()
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

        [Fact]
        public void Calculate_Price_WithDiscount()
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

            pizza.CurrentDiscount = new Discount
            {
                Name = "D1",
                Value = 0.1m
            };

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsLess()
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

            pizza.CurrentDiscount = new Discount
            {
                Name = "D1",
                Value = 0.1m,
                MinPrice = 30m
            };

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsGrater()
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

            pizza.CurrentDiscount = new Discount
            {
                Name = "D1",
                Value = 0.1m,
                MinPrice = 35m
            };

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(33, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsEqual()
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

            pizza.CurrentDiscount = new Discount
            {
                Name = "D1",
                Value = 0.1m,
                MinPrice = 33m
            };

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }
    }
}
