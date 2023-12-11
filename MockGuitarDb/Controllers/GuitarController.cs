using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockGuitarDb.Models.Dtos;
using MockGuitarDb.Models;
using Microsoft.AspNetCore.Authorization;

namespace MockGuitarDb.Controllers
{
    //[Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly ILogger<GuitarController> logger;

        public GuitarController(ILogger<GuitarController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        [Route("/GetAll")]
        public IActionResult GetAll()
        {
            List<Guitar> guitars = new List<Guitar> { new Guitar
            {
                Id = 1,
                BodyStyle = BodyStyle.LesPaul,
                Brand = "Epiphone",
                Model = "Vivian Campbell “Holy Diver”"
            },new Guitar {
                Id = 2,
                BodyStyle = BodyStyle.SuperStrat,
                Brand = "Kiesel",
                Model = "Theos"
            },new Guitar{
                Id = 3,
                BodyStyle = BodyStyle.Stratocaster,
                Brand = "Fender",
                Model = "MN 3TS"
            }};

            List<GuitarDto> guitarDtos = new List<GuitarDto>();

            foreach (var item in guitars)
            {
                GuitarDto dto = new GuitarDto
                {
                    BodyStyle = item.BodyStyle.ToString(),
                    Brand = item.Brand,
                    Model = item.Model
                };
                guitarDtos.Add(dto);
            }

            Thread.Sleep(3000); //WAIT TIME TO MAKE IT CONVINCING
            return Ok(guitarDtos);
        }

        [HttpGet]
        [Route("/GetOne/{id}")]
        public IActionResult GetOne(int id)
        {
            Guitar guitar = new Guitar()
            {
                Id = id,
                BodyStyle = BodyStyle.FlyingV,
                Brand = "Jackson",
                Model = "RR24 Randy Rhoads MIJ"
            };
            GuitarDto dto = new GuitarDto()
            {
                Id = guitar.Id,
                BodyStyle = guitar.BodyStyle.ToString(),
                Brand = guitar.Brand,
                Model = guitar.Model
            };

            Thread.Sleep(3000);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            string returnString = $"Guitar with the id {id} was succesfully deleted.";
            Thread.Sleep(3000);
            return Ok(returnString);
        }
        [HttpPost]
        [Route("/Create")]
        public IActionResult Create([FromBody] GuitarDto guitarDto)
        {
            Thread.Sleep(3000);
            return CreatedAtAction(nameof(Create), guitarDto.Id, guitarDto);
        }
        [HttpPut]
        [Route("/Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GuitarDto guitarDto)
        {
            guitarDto.Id = id;
            GuitarUpdateResponseDto guitarUpdateResponseDto = new GuitarUpdateResponseDto()
            {
                Message = "Guitar succesfully updated!",
                GuitarDto = guitarDto
            };
            Thread.Sleep(3000);
            return Ok(guitarUpdateResponseDto);
        }
    }
}
