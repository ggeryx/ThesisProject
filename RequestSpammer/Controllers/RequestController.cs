using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestSpammer.Models.Dtos;
using System.Diagnostics;

namespace RequestSpammer.Controllers
{
    [Route("api/[controller]/")]
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
        [Route("SingleRequest")]
        public IActionResult SingleRequest()
        {
            var result = requestSpammerLogic.SendRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("ThousandRequests")]
        public IActionResult ThousandRequests()
        {
            List<ProcessResponseDto> results = new List<ProcessResponseDto>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                results.Add(requestSpammerLogic.SendRequest());
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            return Ok(results);
        }
    }
}
