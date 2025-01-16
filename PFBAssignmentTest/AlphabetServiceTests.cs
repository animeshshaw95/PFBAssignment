using PFBAssignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFBAssignmentTest
{
    /// <summary>
    /// Unit tests for the AlphabetService class.
    /// </summary>
    public class AlphabetServiceTests
    {
        private readonly AlphabetService _alphabetService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabetServiceTests"/> class.
        /// </summary>
        public AlphabetServiceTests()
        {
            _alphabetService = new AlphabetService();
        }

        /// <summary>
        /// Tests that ContainsAllAlphabets returns true when the input string contains all alphabets.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainsAllAlphabets_WithAllAlphabets_ReturnsTrue()
        {
            // Arrange
            string input = "abcdefghijklmnopqrstuvwxyz";

            // Act
            bool result = await _alphabetService.ContainsAllAlphabets(input);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that ContainsAllAlphabets returns false when the input string does not contain all alphabets.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainsAllAlphabets_WithoutAllAlphabets_ReturnsFalse()
        {
            // Arrange
            string input = "Hello world";

            // Act
            bool result = await _alphabetService.ContainsAllAlphabets(input);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that ContainsAllAlphabets returns false when the input string is empty.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ContainsAllAlphabets_WithEmptyInput_ReturnsFalse()
        {
            // Arrange
            string input = "";

            // Act
            bool result = await _alphabetService.ContainsAllAlphabets(input);

            // Assert
            Assert.False(result);
        }
    }
}