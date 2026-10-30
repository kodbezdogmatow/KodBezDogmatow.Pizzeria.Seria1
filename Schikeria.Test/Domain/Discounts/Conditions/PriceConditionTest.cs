using Schikeria.Domain.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Model.Pizzas;

namespace Schikeria.Test.Domain.Discounts.Conditions
{
    public class PriceConditionTest
    {
        [Theory]
        [InlineData(2.5)]
        [InlineData(1.35)]
        public void IsSatisfied_Successfully(
            decimal secondOrderItemPrice)
        {
            // Arrange
            var discount = new PriceDiscount
            {
                Name = "Test",
                MinPrice = 4.35m,
                Value = 0m
            };

            var order = new Order
            {
                Items =
                [
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        TotalPrice = 3m
                    },
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        TotalPrice = secondOrderItemPrice
                    }
                ]
            };


            // Act
            var service = new PriceCondition();
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfied_Fail()
        {
            // Arrange
            var discount = new PriceDiscount
            {
                Name = "Test",
                MinPrice = 4.35m,
                Value = 0m
            };

            var order = new Order
            {
                Items =
                [
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        TotalPrice = 4m
                    },
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        TotalPrice = 0.34m
                    }
                ]
            };


            // Act
            var service = new PriceCondition();
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.False(result);
        }
    }
}
