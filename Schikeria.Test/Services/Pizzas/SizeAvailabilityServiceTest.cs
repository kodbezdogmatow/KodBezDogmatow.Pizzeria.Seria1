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

            // Act
            var service = new SizeAvailabilityService();
            var result = service.Validate(
                Names.Weganska, Sizes.XXL);

            // Assert
            Assert.False(result);
        }

        [Fact(Skip ="Niemozliwe rozsadnie do przetestowania bez DI")]
        public void Hawajska_XXL_NotAvailable()
        {
            // Arrange

            // Act
            var service = new SizeAvailabilityService();

            var result = service.Validate(
                Names.Hawajska, Sizes.XXL);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Diavola_S_NotAvailable()
        {
            // Arrange
   
            // Act
            var service = new SizeAvailabilityService();
            var result = service.Validate(
                Names.Diavola, Sizes.Small);

            // Assert
            Assert.False(result);
        }

        [Fact(Skip ="Niemozliwe rozsadnie do przetestowania bez DI")]
        public void Salami_XXL_NotAvailable()
        {
            // Arrange
  
            // Act
            var service = new SizeAvailabilityService();
            var result = service.Validate(
                Names.Salami, Sizes.XXL);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void CurrentSize_Is_None()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = Names.Weganska,
                CurrentSize = Sizes.None
            };

            // Act
            var service = new SizeAvailabilityService();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var result = service.Validate(
                    Names.Weganska, Sizes.None);
            });
        }
    }
}
