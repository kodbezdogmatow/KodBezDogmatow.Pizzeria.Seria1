using Schikeria.Providers.Rules.Pizzas.Sizes;

namespace Schikeria.Test.Providers.Rules.Pizzas.Sizes
{
    public class NotAvailabilityRuleProviderTest
    {
        [Fact(Skip = "Czekamy na DI")]
        public void Get_HasDuplicates()
        {
            // Arrange

            // Act

            // TODO: Inject DuplicationService -> DI :(
            var provider = new NotAvailabilityRuleProvider();
            var result = provider.Get();

            // Assert
        }
    }
}
