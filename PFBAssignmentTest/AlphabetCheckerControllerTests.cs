using System.Net.NetworkInformation;

namespace PFBAssignmentTest
{
    using PFBAssignment.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    public class AlphabetCheckerControllerTests
    {
        private readonly AlphabetCheckerController _controller;

        public AlphabetCheckerControllerTests()
        {
            _controller = new AlphabetCheckerController();
        }

        [Fact]
        public void ShouldReturnTrue_WhenInputContainsAllAlphabets()
        {
            // Arrange
            string input = "abcdefghijklmnopqrstuvwxyz";

            // Act
            var result = _controller.ContainsAllAlphabets(input) as OkObjectResult;
            var response = JObject.Parse(JsonConvert.SerializeObject(result?.Value));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(Convert.ToBoolean(response!["containsAllAlphabets"]));
        }

        [Fact]
        public void ShouldReturnFalse_WhenInputDoesNotContainAllAlphabets()
        {
            // Arrange
            string input = "Hello World";

            // Act
            var result = _controller.ContainsAllAlphabets(input) as OkObjectResult;
            var response = JObject.Parse(JsonConvert.SerializeObject(result?.Value));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.False(Convert.ToBoolean(response!["containsAllAlphabets"]));
        }

        [Fact]
        public void ShouldReturnBadRequest_WhenInputIsNullOrEmpty()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var result = _controller.ContainsAllAlphabets(input) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Input cannot be null or empty.", result.Value);
        }
    }
}