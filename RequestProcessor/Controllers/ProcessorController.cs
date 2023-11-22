using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RequestProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly ILogger<ProcessorController> logger;

        public ProcessorController(ILogger<ProcessorController> logger) 
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("/Process")]
        public IActionResult Process([FromBody] DateTime RequestSent)
        {
            var travelTime = DateTime.UtcNow.Subtract(RequestSent);

            return Ok(travelTime);
        }
    }
}
