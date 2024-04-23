using Moq;
using NUnit.Framework;
using TestingAssignmentProject;

namespace TestingAssignmentProject.Test
{
    [TestFixture]
    public class InsuranceServiceTest
    {

        [Test]
        public void CalculatePremium_WhenRural_BetweenAge18and30()
        {
            // Arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(1.0);  // No discount
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            double premium = insuranceService.CalcPremium(25, "rural");

            // Assert
            Assert.That(premium, Is.EqualTo(5.0));  // Expected premium is 5.0 for rural location and age between 18 and 30
        }
    }
}
