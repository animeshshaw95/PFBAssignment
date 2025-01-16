using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFBAssignment.Service
{
    /// <summary>
    /// Interface for services related to alphabet checking.
    /// </summary>
    public interface IAlphabetService
    {
        /// <summary>
        /// Checks if the given input string contains all alphabets.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A boolean value indicating whether the input string contains all alphabets.</returns>
        Task<bool> ContainsAllAlphabets(string input);
    }
}