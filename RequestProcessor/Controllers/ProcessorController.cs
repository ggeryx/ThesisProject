﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestProcessor.Models.Dtos;

namespace RequestProcessor.Controllers
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
                ProcessorId = "Sent by RequestProcessor (localhost:5004)"
            };

            return Ok(response);
        }
    }
}
