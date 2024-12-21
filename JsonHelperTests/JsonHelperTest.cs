using ClassLibrary1;
using System.Text.Json;

namespace JsonHelperTests
{
    public class JsonHelperTest
    {
        [Fact]
        public void SaveToJson_ShouldSaveDataToFile()
        {
            // Arrange
            var testFileName = "test_file.json";
            var testData = new List<string> { "Poghos", "Petros" };

            // Act
            JsonHelper.SaveToJson(testData, testFileName);

            // Assert
            Assert.True(File.Exists(testFileName));

            var fileContent = File.ReadAllText(testFileName);
            var result = JsonSerializer.Deserialize<List<string>>(fileContent);
            Assert.Equal(testData, result);

            File.Delete(testFileName);
        }
    }
}