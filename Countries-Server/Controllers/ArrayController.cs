using Countries_Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Countries_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        private readonly ILogger<ArrayController> _logger;

        public ArrayController(ILogger<ArrayController> logger)
        {
           _logger = logger;
        }

        [HttpPost]
        [Route("second-largest")]
        public IActionResult GetSecondLargest([FromBody] RequestObj request)
        {
            if (request.RequestArrayObj == null || request.RequestArrayObj.Count() < 2)
            {
                return BadRequest("Array must have at least two integers.");
            }

            var distinctSortedArray = request.RequestArrayObj.Distinct().OrderByDescending(x => x).ToList();

            if (distinctSortedArray.Count < 2)
            {
                return BadRequest("Array must have at least two unique integers.");
            }

            return Ok(distinctSortedArray[1]); 
        }
    }
}
