using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RequestSpammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> logger;
        private readonly IRequestSpammerLogic requestSpammerLogic;

        public RequestController(ILogger<RequestController> logger, IRequestSpammerLogic requestSpammerLogic)
        {
            this.logger = logger;
            this.requestSpammerLogic = requestSpammerLogic;
        }

        [HttpPost]
        public IActionResult SingleRequest()
        {
            var result = requestSpammerLogic.SendRequest();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult ThousandRequests()
        {
            List<string> results = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                results.Add(requestSpammerLogic.SendRequest());
            }
            return Ok(results);
        }
    }
}
