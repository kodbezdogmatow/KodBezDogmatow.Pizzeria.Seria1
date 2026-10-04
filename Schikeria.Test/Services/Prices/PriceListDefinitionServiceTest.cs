using Moq;
using Schikeria.Interfaces.Factories.Prices;
using Schikeria.Interfaces.Providers.Prices;
using Schikeria.Model.Pizzas;
using Schikeria.Model.Prices;
using Schikeria.Services.Prices;

namespace Schikeria.Test.Services.Prices
{
    public class PriceListDefinitionServiceTest
    {
        [Fact]
        public void Define_Successfully()
        {
            // Arrange
            var priceListFactory = new Mock<IPriceListFactory>();
            var hardcodedPizzaPriceProvider = new Mock<IHardcodedPizzaPriceProvider>();
            var priceTestValue = 10;
            
            var priceList = new PriceList
            {
                Items =
                [
                    new PriceListItem 
                    { 
                        PizzaName = "Test1", 
                        Size = Sizes.None
                    },
                    new PriceListItem
                    {
                        PizzaName = "Test2",
                        Size = Sizes.None
                    },
                    new PriceListItem
                    {
                        PizzaName = "Test3",
                        Size = Sizes.None
                    },
                    new PriceListItem
                    {
                        PizzaName = "Test4",
                        Size = Sizes.None
                    },
                    new PriceListItem
                    {
                        PizzaName = "Test5",
                        Size = Sizes.None
                    },
                ]
            };

            priceListFactory
                .Setup(m => m.Create())
                .Returns(priceList);

            hardcodedPizzaPriceProvider
                .Setup(m => m.Get(It.IsAny<string>(), It.IsAny<Sizes>()))
                .Returns((string name, Sizes size) =>
                {
                    var item = priceList.Items
                        .First(i => i.PizzaName == name);

                    return (priceList.Items.IndexOf(item) + 1) * priceTestValue;
                });

            // Act
            var service = new PriceListDefinitionService(
                priceListFactory.Object,
                hardcodedPizzaPriceProvider.Object);

            var result = service.Define();

            // Assert
            result.Items
                .ForEach(i =>
                {
                    var priceIndex = result.Items.IndexOf(i) + 1;
                    var testPrice = priceIndex * priceTestValue;
                    Assert.Equal(testPrice, i.Price);
                });

            Assert.Same(priceList, result);
        }
    }
}
