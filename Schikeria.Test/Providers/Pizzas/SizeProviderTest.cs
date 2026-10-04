using Schikeria.Model.Pizzas;
using Schikeria.Providers.Pizzas;

namespace Schikeria.Test.Providers.Pizzas
{
    public class SizeProviderTest
    {
        [Fact]
        public void Get_CheckNone()
        {
            // Arrange

            // Act
            var provider = new SizeProvider();
            var result = provider.GetAll();

            // Assert
            Assert.True(result.All(s => s != Sizes.None));
        }
    }
}
