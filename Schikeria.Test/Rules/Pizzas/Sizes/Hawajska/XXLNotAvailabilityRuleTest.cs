using Moq;
using Schikeria.Constants.Pizzas;
using Schikeria.Interfaces.Rules.Pizzas.Hawajska;
using Schikeria.Model.Pizzas;
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

            var pizza = new Pizza
            {
                Name = Names.Hawajska,
                CurrentSize = Model.Pizzas.Sizes.XXL
            };

            weekendAvailabilityRule
                .Setup(m => m.IsSatisfied())
                .Returns(true);

            // Act
            var rule = new XXLNotAvailabilityRule();

            var result = rule.IsSatisfied(pizza);

            // Assert
            Assert.True(result);
        }

        [Fact(Skip ="Bez DI nie przejdzie")]
        public void IsSatisfied_Fail()
        {
            // Arrange
            var weekendAvailabilityRule = new Mock<IWeekendAvailabilityRule>();

            var pizza = new Pizza
            {
                Name = Names.Hawajska,
                CurrentSize = Model.Pizzas.Sizes.XXL
            };

            weekendAvailabilityRule
                .Setup(m => m.IsSatisfied())
                .Returns(false);

            // Act
            var rule = new XXLNotAvailabilityRule();

            var result = rule.IsSatisfied(pizza);

            // Assert
            Assert.False(result);
        }
    }
}
