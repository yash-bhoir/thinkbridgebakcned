using Microsoft.AspNetCore.Mvc;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            string? result = null;

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("No data available");
            }

            return Ok(new 
            { 
                message = "Data fetched",
                data = result 
            });

        }
    }
}