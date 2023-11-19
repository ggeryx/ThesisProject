using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "HelloWorld")]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}