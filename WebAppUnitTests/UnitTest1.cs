using Xunit;
using FirstResponsiveWebAppElliott;
using FirstResponsiveWebAppElliott.Models;

namespace WebAppUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingCase1_BDatePriorToNow()
        {
            // Arrange
            AgeFinderModel testModel = new AgeFinderModel();
            testModel.BirthYear = new DateTime(1983, 02, 24);

            int expected = 40;
            int? actual;

            // Act
            actual = testModel.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PassingCase2_BDateAfterNow()
        {
            // Arrange
            AgeFinderModel testModel = new AgeFinderModel();
            testModel.BirthYear = new DateTime(1983, 11, 24);

            int expected = 39;
            int? actual;

            // Act
            actual = testModel.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FailureCase_DateNotEqualToAge()
        {
            // Arrange
            AgeFinderModel testModel = new AgeFinderModel();
            testModel.BirthYear = new DateTime(1982, 02, 24);

            int expected = 40;
            int? actual;

            // Act
            actual = testModel.AgeThisYear();

            // Assert
            Assert.NotEqual(expected, actual);
        }
    }
}