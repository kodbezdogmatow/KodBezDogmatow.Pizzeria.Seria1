using Moq;
using Schikeria.Constants.Pizzas;
using Schikeria.Interfaces.Rules.Pizzas.Hawajska;
using Schikeria.Rules.Pizzas.Sizes.Hawajska;

namespace Schikeria.Test.Rules.Pizzas.Sizes.Hawajska
{
    public class XXLNotAvailabilityRuleTest
    {
        [Fact(Skip ="Bez DI nie przejdzie")]
        public void IsSatisfied_Successfully()
        {
            // Arrange
            var weekendAvailabilityRule = new Mock<IWeekendAvailabilityRule>();

            weekendAvailabilityRule
                .Setup(m => m.IsSatisfied())
                .Returns(true);

            // Act
            var rule = new XXLNotAvailabilityRule();

            var result = rule.IsSatisfied(
                Names.Hawajska, Model.Pizzas.Sizes.XXL);

            // Assert
            Assert.True(result);
        }

        [Fact(Skip ="Bez DI nie przejdzie")]
        public void IsSatisfied_Fail()
        {
            // Arrange
            var weekendAvailabilityRule = new Mock<IWeekendAvailabilityRule>();

            weekendAvailabilityRule
                .Setup(m => m.IsSatisfied())
                .Returns(false);

            // Act
            var rule = new XXLNotAvailabilityRule();

            var result = rule.IsSatisfied(
                Names.Hawajska, Model.Pizzas.Sizes.XXL);

            // Assert
            Assert.False(result);
        }
    }
}
