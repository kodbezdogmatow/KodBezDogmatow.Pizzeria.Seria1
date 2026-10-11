using Moq;
using Schikeria.Interfaces.Domain.Discounts.Conditions;
using Schikeria.Interfaces.Providers.Discounts.Conditions;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Services.Discounts.Conditions;

namespace Schikeria.Test.Services.Discounts.Conditions
{
    public class ConditionServiceTest
    {
        [Fact]
        public void IsSatisfied_ConditionWasFound_Successfully()
        {
            // Arrange
            var conditionResult = true;
            var successfullyDiscountKind = DiscountKind.Normal;
            var conditionProvider = new Mock<IConditionProvider>();
            var successfullyDiscountCondition = new Mock<IDiscountCondition>();
            var failDiscountCondition = new Mock<IDiscountCondition>();
            var fail2DiscountCondition = new Mock<IDiscountCondition>();

            var discount = new Discount
            {
                Kind = successfullyDiscountKind,
                Name = "",
                Value = 0
            };

            var order = new Order();

            successfullyDiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(successfullyDiscountKind);

            successfullyDiscountCondition
                .Setup(m => m.IsSatisfied(discount, order))
                .Returns(conditionResult);

            failDiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(DiscountKind.Price);

            fail2DiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(DiscountKind.Group);

            conditionProvider
                .Setup(m => m.Get())
                .Returns(
                [
                    failDiscountCondition.Object,
                    successfullyDiscountCondition.Object,
                    fail2DiscountCondition.Object
                ]);

            // Act
            var service = new ConditionService(
                conditionProvider.Object);
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.True(result);

            failDiscountCondition.VerifyGet(
                m => m.Kind, Times.Once());
            successfullyDiscountCondition.VerifyGet(
                m => m.Kind, Times.Once());
            fail2DiscountCondition.VerifyGet(
                m => m.Kind, Times.Never());

            failDiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Never());
            successfullyDiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Once());
            fail2DiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Never());
        }

        [Fact]
        public void IsSatisfied_ConditionWasNotFound_Successfully()
        {
            // Arrange
            var successfullyDiscountKind = DiscountKind.None;
            var conditionProvider = new Mock<IConditionProvider>();
            var fail3DiscountCondition = new Mock<IDiscountCondition>();
            var failDiscountCondition = new Mock<IDiscountCondition>();
            var fail2DiscountCondition = new Mock<IDiscountCondition>();

            var discount = new Discount
            {
                Kind = successfullyDiscountKind,
                Name = "",
                Value = 0
            };

            var order = new Order();

            fail3DiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(DiscountKind.Normal);

            failDiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(DiscountKind.Price);

            fail2DiscountCondition
                .SetupGet(m => m.Kind)
                .Returns(DiscountKind.Group);

            conditionProvider
                .Setup(m => m.Get())
                .Returns(
                [
                    fail3DiscountCondition.Object,
                    failDiscountCondition.Object,
                    fail2DiscountCondition.Object
                ]);

            // Act
            var service = new ConditionService(
                conditionProvider.Object);
            var result = service.IsSatisfied(discount, order);

            // Assert
            Assert.True(result);

            fail3DiscountCondition.VerifyGet(
                m => m.Kind, Times.Once());
            failDiscountCondition.VerifyGet(
                m => m.Kind, Times.Once());
            fail2DiscountCondition.VerifyGet(
                m => m.Kind, Times.Once());

            fail3DiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Never());
            failDiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Never());
            fail2DiscountCondition.Verify(
                m => m.IsSatisfied(discount, order), Times.Never());
        }
    }
}
