using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestProcessorTypeTwo.Models.Dtos;

namespace RequestProcessorTypeTwo.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly ILogger<ProcessorController> logger;

        public ProcessorController(ILogger<ProcessorController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        [Route("Process")]
        public IActionResult Process([FromBody] ProcessRequestDto processRequestDto)
        {
            var travelTime = DateTime.Now.Subtract(processRequestDto.RequestSent);

            var response = new ProcessResponseDto
            {
                TravelTimeInMilliseconds = travelTime.TotalMilliseconds,
                ProcessorId = "Sent by RequestProcessorTypeTwo (localhost:5005)"
            };

            return Ok(response);
        }
    }
}
