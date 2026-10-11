using Moq;
using Schikeria.Interfaces.Common;
using Schikeria.Interfaces.Domain.Discounts.Calculations;
using Schikeria.Interfaces.Providers.Discounts.Calculations;
using Schikeria.Interfaces.Services.Duplications;
using Schikeria.Model.Discounts;
using Schikeria.Model.Orders;
using Schikeria.Model.Services.Duplications;
using Schikeria.Services.Discounts.Calculations;

namespace Schikeria.Test.Services.Discounts.Calculations
{
    public class CalculationServiceTest
    {
        [Fact]
        public void Calculate_Successfuly()
        {
            // Arrange
            var successfullyCalculationType = CalculationType.FixedAmount;
            var returnPrice = 10.69m;

            var calculationProvider = new Mock<ICalculationProvider>();
            var duplicationService = new Mock<IDuplicationService>();
            var successfullyCalculation = new Mock<IDiscountCalculation>();
            var failfullyCalculation = new Mock<IDiscountCalculation>();
            var fail2Calculation = new Mock<IDiscountCalculation>();

            var discount = new Discount
            {
                Name = "",
                Value = 0,
                CalculationType = successfullyCalculationType,
            };

            var order = new Order();

            List<Duplication> duplications = [];

            successfullyCalculation
                .SetupGet(m => m.CalculationType)
                .Returns(successfullyCalculationType);

            successfullyCalculation
                .Setup(m => m.Calculate(discount, order))
                .Returns(returnPrice);

            failfullyCalculation
                .SetupGet(m => m.CalculationType)
                .Returns(CalculationType.None);

            fail2Calculation
               .SetupGet(m => m.CalculationType)
               .Returns(CalculationType.None);

            calculationProvider
                .Setup(m => m.Get())
                .Returns(
                [
                    failfullyCalculation.Object,
                    successfullyCalculation.Object,
                    fail2Calculation.Object
                ]);

            duplicationService
                .Setup(m => m.Get(It.IsAny<List<IUniqueKey>>()))
                .Returns(duplications);

            // Act
            var service = new CalculationService(
                calculationProvider.Object,
                duplicationService.Object);

            var result = service.Calculate(
                discount, order);

            // Assert
            Assert.Equal(returnPrice, result);

            calculationProvider.Verify(
                m => m.Get(), Times.Once());

            duplicationService.Verify(
                m => m.Get(It.IsAny<List<IUniqueKey>>()), Times.Once());

            failfullyCalculation.VerifyGet(
                m => m.CalculationType, Times.Once());
            successfullyCalculation.VerifyGet(
                m => m.CalculationType, Times.Once());
            fail2Calculation.VerifyGet(
                m => m.CalculationType, Times.Never());

            failfullyCalculation.Verify(
                m => m.Calculate(discount, order), Times.Never());
            successfullyCalculation.Verify(
                m => m.Calculate(discount, order), Times.Once());
            fail2Calculation.Verify(
                m => m.Calculate(discount, order), Times.Never());
        }

        [Fact]
        public void Calculate_Fail_Duplicates()
        {
            // Arrange
            var successfullyCalculationType = CalculationType.FixedAmount;
            var returnPrice = 10.69m;

            var calculationProvider = new Mock<ICalculationProvider>();
            var duplicationService = new Mock<IDuplicationService>();
            var successfullyCalculation = new Mock<IDiscountCalculation>();
            var failfullyCalculation = new Mock<IDiscountCalculation>();
            var fail2Calculation = new Mock<IDiscountCalculation>();

            var discount = new Discount
            {
                Name = "",
                Value = 0,
                CalculationType = successfullyCalculationType,
            };

            var order = new Order();

            List<Duplication> duplications =
                [
                    new Duplication
                    {
                        Count = 2,
                        Key = "Test"
                    }
                ];

            successfullyCalculation
                .SetupGet(m => m.CalculationType)
                .Returns(successfullyCalculationType);

            successfullyCalculation
                .Setup(m => m.Calculate(discount, order))
                .Returns(returnPrice);

            failfullyCalculation
                .SetupGet(m => m.CalculationType)
                .Returns(CalculationType.None);

            fail2Calculation
               .SetupGet(m => m.CalculationType)
               .Returns(CalculationType.None);

            calculationProvider
                .Setup(m => m.Get())
                .Returns(
                [
                    failfullyCalculation.Object,
                    fail2Calculation.Object,
                    successfullyCalculation.Object
                ]);

            duplicationService
                .Setup(m => m.Get(It.IsAny<List<IUniqueKey>>()))
                .Returns(duplications);

            // Act
            var service = new CalculationService(
                calculationProvider.Object,
                duplicationService.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    service.Calculate(
                        discount, order);
                });

                calculationProvider.Verify(
                    m => m.Get(), Times.Once());

                duplicationService.Verify(
                    m => m.Get(It.IsAny<List<IUniqueKey>>()), Times.Once());

                failfullyCalculation.VerifyGet(
                    m => m.CalculationType, Times.Never());
                successfullyCalculation.VerifyGet(
                    m => m.CalculationType, Times.Never());
                fail2Calculation.VerifyGet(
                    m => m.CalculationType, Times.Never());

                failfullyCalculation.Verify(
                    m => m.Calculate(discount, order), Times.Never());
                successfullyCalculation.Verify(
                    m => m.Calculate(discount, order), Times.Never());
                fail2Calculation.Verify(
                    m => m.Calculate(discount, order), Times.Never());
            });
        }


        [Fact]
        public void Calculate_Fail_NoCalculationType()
        {
            // Arrange
            var returnPrice = 10.69m;

            var calculationProvider = new Mock<ICalculationProvider>();
            var duplicationService = new Mock<IDuplicationService>();
            var fail3Calculation = new Mock<IDiscountCalculation>();
            var failfullyCalculation = new Mock<IDiscountCalculation>();
            var fail2Calculation = new Mock<IDiscountCalculation>();

            var discount = new Discount
            {
                Name = "",
                Value = 0,
                CalculationType = CalculationType.Percentage,
            };

            var order = new Order();
            List<Duplication> duplications = [];            

            fail3Calculation
                .SetupGet(m => m.CalculationType)
                .Returns(CalculationType.FixedAmount);

            fail3Calculation
                .Setup(m => m.Calculate(discount, order))
                .Returns(returnPrice);

            failfullyCalculation
                .SetupGet(m => m.CalculationType)
                .Returns(CalculationType.None);

            fail2Calculation
               .SetupGet(m => m.CalculationType)
               .Returns(CalculationType.None);

            calculationProvider
                .Setup(m => m.Get())
                .Returns(
                [
                    failfullyCalculation.Object,
                    fail3Calculation.Object,
                    fail2Calculation.Object
                ]);

            duplicationService
                .Setup(m => m.Get(It.IsAny<List<IUniqueKey>>()))
                .Returns(duplications);

            // Act
            var service = new CalculationService(
                calculationProvider.Object,
                duplicationService.Object);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    service.Calculate(discount, order);

                    calculationProvider.Verify(
                        m => m.Get(), Times.Once());

                    duplicationService.Verify(
                        m => m.Get(It.IsAny<List<IUniqueKey>>()), Times.Once());

                    failfullyCalculation.VerifyGet(
                        m => m.CalculationType, Times.Once());
                    fail3Calculation.VerifyGet(
                        m => m.CalculationType, Times.Once());
                    fail2Calculation.VerifyGet(
                        m => m.CalculationType, Times.Once());

                    failfullyCalculation.Verify(
                        m => m.Calculate(discount, order), Times.Never());
                    fail3Calculation.Verify(
                        m => m.Calculate(discount, order), Times.Never());
                    fail2Calculation.Verify(
                        m => m.Calculate(discount, order), Times.Never());
                });
            });
        }
    }
}
