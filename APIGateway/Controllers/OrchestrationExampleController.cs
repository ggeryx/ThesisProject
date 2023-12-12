using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchestrationExampleController : ControllerBase
    {
        private readonly ILogger<OrchestrationExampleController> logger;

        public OrchestrationExampleController(ILogger<OrchestrationExampleController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("ThisIsSparta")]
        public async Task<IActionResult> ThisIsSparta()
        {


            return Ok();
        }
    }
}
