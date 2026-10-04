using Moq;
using Schikeria.Factories.Prices;
using Schikeria.Interfaces.Providers.Pizzas;
using Schikeria.Interfaces.Services.Pizzas;
using Schikeria.Model.Pizzas;

namespace Schikeria.Test.Factories.Prices
{
    public class PriceListFactoryTest
    {
        [Fact]
        public void Create_Successfully()
        {
            // Arrange
            const string PizzaName1 = "Name1";
            const string PizzaName2 = "Name2";
            const string PizzaName3 = "Name3";

            var nameProvider = new Mock<INameProvider>();
            var sizeProvider = new Mock<ISizeProvider>();
            var sizeAvailabilityService = new Mock<ISizeAvailabilityService>();

            var notAvailablePizzas = new[]
            {
                new { Name = PizzaName1, Size = Sizes.Medium },
                new { Name = PizzaName2, Size = Sizes.Small },
                new { Name = PizzaName3, Size = Sizes.Large }
            };

            List<string> names = [
                    PizzaName1,
                    PizzaName2,
                    PizzaName3
                ];

            List<Sizes> sizes = [
                    Sizes.Small,
                    Sizes.Medium,
                    Sizes.Large
                ];

            nameProvider
                .Setup(m => m.GetAll())
                .Returns(names);

            sizeProvider
                .Setup(m => m.GetAll())
                .Returns(sizes);

            sizeAvailabilityService
                .Setup(m => m.Validate(
                    It.IsAny<string>(),
                    It.IsAny<Sizes>()))
                .Returns((string name, Sizes size) =>
                {
                    var isNotAvailable = notAvailablePizzas
                        .Any(p => p.Name == name && p.Size == size);

                    return !isNotAvailable;
                });

            // Act
            var factory = new PriceListFactory(
                nameProvider.Object,
                sizeProvider.Object,
                sizeAvailabilityService.Object);

            var result = factory.Create();

            // Assert
            var availablePriceListItemsCount = (names.Count * sizes.Count) -
                notAvailablePizzas.Count();

            Assert.Equal(availablePriceListItemsCount, result.Items.Count);

            notAvailablePizzas
                .ToList()
                .ForEach(p =>
                {
                    Assert.Null(result.Items.FirstOrDefault(
                        i => i.PizzaName == p.Name && i.Size == p.Size));
                });
        }
    }
}
