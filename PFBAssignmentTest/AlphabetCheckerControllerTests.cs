using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PFBAssignment.Controllers;
using PFBAssignment.Service;
using System.Net.NetworkInformation;

namespace PFBAssignmentTest
{
    /// <summary>
    /// Unit tests for the AlphabetCheckerController class.
    /// </summary>
    public class AlphabetCheckerControllerTests
    {
        private readonly AlphabetCheckerController _controller;
        private readonly Mock<IAlphabetService> _mockAlphabetService;

        public AlphabetCheckerControllerTests()
        {
            _mockAlphabetService = new Mock<IAlphabetService>();
            _controller = new AlphabetCheckerController(_mockAlphabetService.Object);
        }

        /// <summary>
        /// Tests that the controller returns a 200 OK status code and a true response when the input string contains all alphabets.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnTrue_WhenInputContainsAllAlphabets()
        {
            // Arrange
            string input = "abcdefghijklmnopqrstuvwxyz";
            _mockAlphabetService.Setup(s => s.ContainsAllAlphabets(input)).ReturnsAsync(true);

            // Act
            var result = await _controller.ContainsAllAlphabets(input) as OkObjectResult;
            var response = JObject.Parse(JsonConvert.SerializeObject(result?.Value));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(Convert.ToBoolean(response["containsAllAlphabets"]));
        }

        /// <summary>
        /// Tests that the controller returns a 200 OK status code and a false response when the input string does not contain all alphabets.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnFalse_WhenInputDoesNotContainAllAlphabets()
        {
            // Arrange
            string input = "Hello World";
            _mockAlphabetService.Setup(s => s.ContainsAllAlphabets(input)).ReturnsAsync(false);

            // Act
            var result = await _controller.ContainsAllAlphabets(input) as OkObjectResult;
            var response = JObject.Parse(JsonConvert.SerializeObject(result?.Value));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.False(Convert.ToBoolean(response["containsAllAlphabets"]));
        }

        /// <summary>
        /// Tests that the controller returns a 400 Bad Request status code when the input string is null or empty.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnBadRequest_WhenInputIsNullOrEmpty()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var result = await _controller.ContainsAllAlphabets(input) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Input cannot be null or empty.", result.Value);
        }
    }
}