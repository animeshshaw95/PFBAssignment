using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PFBAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetCheckerController : ControllerBase
    {
        [HttpPost("contains-all-alphabets")]
        public IActionResult ContainsAllAlphabets([FromBody] string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return BadRequest("Input cannot be null or empty.");
            }
            var allLetters = Enumerable.Range('a', 26).Select(c => (char)c).ToList();

            bool containsAllAlphabets = allLetters.All(input.ToLower().ToCharArray().Distinct().Contains);

            return Ok(new { containsAllAlphabets });
        }
    }
}
