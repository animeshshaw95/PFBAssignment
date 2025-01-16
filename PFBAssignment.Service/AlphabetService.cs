using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFBAssignment.Service
{
    /// <summary>
    /// Provides methods for checking if a string contains all alphabets.
    /// </summary>
    public class AlphabetService : IAlphabetService
    {
        /// <summary>
        /// Checks if the given input string contains all alphabets.
        /// </summary>
        /// <param name="input">The input string to be checked.</param>
        /// <returns>True if the input string contains all alphabets, otherwise false.</returns>
        public async Task<bool> ContainsAllAlphabets(string input)
        {
            // Create a list of all lowercase alphabets
            var allLetters = Enumerable.Range('a', 26).Select(c => (char)c).ToList();

            // Get distinct lowercase characters from the input
            var allInputCharacters = input.ToLower().ToCharArray().Distinct();

            // Check if all lowercase letters are present in the input
            return allLetters.All(letter => allInputCharacters.Contains(letter));
        }
    }
}