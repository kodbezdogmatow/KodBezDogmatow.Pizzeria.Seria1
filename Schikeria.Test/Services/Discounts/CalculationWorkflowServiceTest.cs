using Moq;
using Schikeria.Interfaces.Services.Discounts.Calculations;
using Schikeria.Interfaces.Services.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Model.Pizzas;
using Schikeria.Services.Discounts;

namespace Schikeria.Test.Services.Discounts
{
    public class CalculationWorkflowServiceTest
    {
        [Fact]
        public void Calculate_Successfully_DiscountWasApplied()
        {
            // Arrange
            const decimal returnPrice = 10.69m;

            var conditionService = new Mock<IConditionService>();
            var calculationService = new Mock<ICalculationService>();

            var discount = new Discount
            {
                Name = "",
                Value = 0
            };

            var order = new Order();

            conditionService
                .Setup(m => m.IsSatisfied(discount, order))
                .Returns(true);

            calculationService
                .Setup(m => m.Calculate(discount, order))
                .Returns(returnPrice);

            // Act
            var service = new CalculationWorkflowService(
                conditionService.Object,
                calculationService.Object);

            var result = service.Calculate(
                discount, order);

            // Assert
            Assert.Equal(returnPrice, result);

            conditionService.Verify(
                m => m.IsSatisfied(discount, order), Times.Once);

            calculationService.Verify(
                m => m.Calculate(discount, order), Times.Once);
        }

        [Fact]
        public void Calculate_Successfully_DiscountWasNotApplied()
        {
            // Arrange
            const decimal returnPrice = 10.69m;

            var conditionService = new Mock<IConditionService>();
            var calculationService = new Mock<ICalculationService>();

            var discount = new Discount
            {
                Name = "",
                Value = 0
            };

            var order = new Order
            {
                Items =
                [
                    new OrderItem
                    {
                        TotalPrice = 12.69m,
                        Pizza = new Pizza
                        {
                            Name = ""
                        }
                    }
                ]
            };

            conditionService
                .Setup(m => m.IsSatisfied(discount, order))
                .Returns(false);

            calculationService
                .Setup(m => m.Calculate(discount, order))
                .Returns(returnPrice);

            // Act
            var service = new CalculationWorkflowService(
                conditionService.Object,
                calculationService.Object);

            var result = service.Calculate(
                discount, order);

            // Assert
            Assert.NotEqual(returnPrice, result);
            Assert.Equal(order.TotalPrice, result);

            conditionService.Verify(
                m => m.IsSatisfied(discount, order), Times.Once);

            calculationService.Verify(
                m => m.Calculate(discount, order), Times.Never);
        }
    }
}
