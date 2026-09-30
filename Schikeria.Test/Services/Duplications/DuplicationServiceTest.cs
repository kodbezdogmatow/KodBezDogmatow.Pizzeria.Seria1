using Moq;
using Schikeria.Interfaces.Common;
using Schikeria.Services.Duplications;

namespace Schikeria.Test.Services.Duplications
{
    public class DuplicationServiceTest
    {
        [Fact]
        public void Get_HasDuplicates()
        {
            const string firstDuplicatedKey = "FirstDuplicate";
            const string secondDuplicatedKey = "SecondDuplicate";

            // Arrange
            var item1 = new Mock<IUniqueKey>();
            var item2_1 = new Mock<IUniqueKey>();
            var item2_2 = new Mock<IUniqueKey>();
            var item3_1 = new Mock<IUniqueKey>();
            var item3_2 = new Mock<IUniqueKey>();
            var item3_3 = new Mock<IUniqueKey>();

            List<IUniqueKey> items = [
                    item1.Object,
                    item2_1.Object,
                    item2_2.Object,
                    item3_1.Object,
                    item3_2.Object,
                    item3_3.Object
                ];

            item1
                .Setup(m => m.GetUniqueKey())
                .Returns(Guid.NewGuid().ToString());
            item2_1
                .Setup(m => m.GetUniqueKey())
                .Returns(firstDuplicatedKey);
            item2_2
                .Setup(m => m.GetUniqueKey())
                .Returns(firstDuplicatedKey);
            item3_1
                .Setup(m => m.GetUniqueKey())
                .Returns(secondDuplicatedKey);
            item3_2
                .Setup(m => m.GetUniqueKey())
                .Returns(secondDuplicatedKey);
            item3_3
                .Setup(m => m.GetUniqueKey())
                .Returns(secondDuplicatedKey);

            // Act
            var service = new DuplicationService();
            var result = service.Get(items);

            // Assert
            Assert.Equal(2, result.Count);

            var firstDuplicateInfo = result
                .First(r => r.Key == firstDuplicatedKey);
            Assert.Equal(
                firstDuplicateInfo.Count,
                items.Count(i => 
                    i.GetUniqueKey() == firstDuplicatedKey));

            var secondDuplicateInfo = result
                .First(r => r.Key == secondDuplicatedKey);

            Assert.Equal(
                secondDuplicateInfo.Count,
                items.Count(i =>
                    i.GetUniqueKey() == secondDuplicatedKey));
        }
    }
}
