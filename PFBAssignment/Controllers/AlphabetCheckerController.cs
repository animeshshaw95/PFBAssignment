using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFBAssignment.Service;
using System.Linq;

namespace PFBAssignment.Controllers
{
    /// <summary>
    /// API controller for checking if a given string contains all alphabets.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetCheckerController : ControllerBase
    {
        private readonly IAlphabetService _alphabetService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabetCheckerController"/> class.
        /// </summary>
        /// <param name="alphabetService">The alphabet service.</param>
        public AlphabetCheckerController(IAlphabetService alphabetService)
        {
            _alphabetService = alphabetService;
        }

        /// <summary>
        /// Checks if the given input string contains all alphabets.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>An IActionResult indicating the result.</returns>
        [HttpPost("contains-all-alphabets")]
        public async Task<IActionResult> ContainsAllAlphabets([FromBody] string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return BadRequest("Input cannot be null or empty.");
            }

            bool result = await _alphabetService.ContainsAllAlphabets(input);

            return Ok(new { containsAllAlphabets = result });
        }
    }
}