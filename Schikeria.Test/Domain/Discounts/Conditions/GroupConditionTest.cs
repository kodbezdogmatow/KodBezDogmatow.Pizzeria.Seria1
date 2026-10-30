using Schikeria.Domain.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Model.Pizzas;

namespace Schikeria.Test.Domain.Discounts.Conditions
{
    public class GroupConditionTest
    {
        [Theory]
        [InlineData(4)]
        [InlineData(1)]
        public void IsSatisfied_Successfully(
            int secondOrderItemCount)
        {
            // Arrange
            var discount = new GroupDiscount
            {
                Name = "Test",
                MinCount = 5,
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
                        Count = 4
                    },
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        Count = secondOrderItemCount
                    }
                ]
            };


            // Act
            var service = new GroupCondition();
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSatisfied_Fail()
        {
            // Arrange
            var discount = new GroupDiscount
            {
                Name = "Test",
                MinCount = 5,
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
                        Count = 1
                    },
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        Count = 2
                    }
                ]
            };


            // Act
            var service = new GroupCondition();
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.False(result);
        }
    }
}
