using Moq;
using NUnit.Framework;
using TestingAssignmentProject;

namespace TestingAssignmentProject.Test
{
    [TestFixture]
    public class InsuranceServiceTest
    {

        [TestCase(19, "rural", 5.0)]
        [TestCase(32, "rural", 2.5)]
        [TestCase(15, "rural", 0.0)]
        [TestCase(19, "urban", 6.0)]
        [TestCase(37, "urban", 5.0)]
        [TestCase(15, "urban", 0.0)]
        [TestCase(51, "suburban", 0.0)]
        [TestCase(51, "urban", 2.5)]

        [Test]
        public void CalculatePremium_WhenLocationAndAgeEntered(int age, string location, double expectedPremium)
        {
            // Arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);  //set discount at 50%
            var insuranceService = new InsuranceService(mockDiscountService.Object);

            // Act
            double premium = insuranceService.CalcPremium(age, location);

            // Assert
            Assert.That(premium, Is.EqualTo(expectedPremium)); 
        }
    }
}
