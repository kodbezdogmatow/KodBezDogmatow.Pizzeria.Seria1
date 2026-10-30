using Schikeria.Domain.Discounts.Calculations;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Model.Pizzas;

namespace Schikeria.Test.Domain.Discounts.Calculations
{
    public class PercentageCalculationTest
    {
        [Fact]
        public void Calculate_Successfully()
        {
            // Arrange
            var discount = new Discount
            {
                Name = "Test",
                Value = 0.45m
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
                        TotalPrice = 7.5m
                    },
                    new OrderItem
                    {
                        Pizza = new Pizza
                        {
                            Name = ""
                        },
                        TotalPrice = 2.5m
                    }
                ]
            };


            // Act
            var service = new PercentageCalculation();
            var result = service.Calculate(discount, order);

            // Assert
            Assert.Equal(5.5m, result);
        }
    }
}
