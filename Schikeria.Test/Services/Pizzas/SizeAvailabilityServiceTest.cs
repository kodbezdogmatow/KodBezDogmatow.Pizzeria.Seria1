using Schikeria.Constants.Pizzas;
using Schikeria.Model.Pizzas;
using Schikeria.Services.Pizzas;

namespace Schikeria.Test.Services.Pizzas
{
    public class SizeAvailabilityServiceTest
    {
        [Fact]
        public void Weganska_XXL_NotAvailable()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = Names.Weganska,
                CurrentSize = Sizes.XXL
            };

            // Act
            var service = new SizeAvailabilityService();
            var result = service.Validate(pizza);

            // Assert
            Assert.False(result);
        }
    }
}
