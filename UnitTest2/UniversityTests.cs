using ClassLibrary2;

namespace UnitTest2
{
    public class UniversityTests
    {
        [Fact]
        public void University_ShouldHaveCorrectName()
        {
            // Arrange
            string universityName = "Polytech";

            // Act
            var university = new University(universityName);

            // Assert
            Assert.Equal(universityName, university.Name);
        }
    }
}