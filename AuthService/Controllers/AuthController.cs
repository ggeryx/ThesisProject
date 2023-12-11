using AuthService.Models.Dtos;
using AuthService.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            if (registerRequestDto.Roles.IsNullOrEmpty())
            {
                return BadRequest("Roles can't be empty.");
            }

            var result = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest("Something went wrong during the registration process.");
            }

            result = await userManager.AddToRolesAsync(user, registerRequestDto.Roles);
            if (!result.Succeeded)
            {
                await userManager.DeleteAsync(user);
                return BadRequest("Something went wrong during the registration process.");
            }

            return Ok("Succesfull registration!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user == null)
            {
                return BadRequest("Incorrect credentials.");
            }

            var pwCheck = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (pwCheck == false)
            {
                return BadRequest("Incorrect credentials.");
            }

            var roles = await userManager.GetRolesAsync(user);

            var token = tokenRepository.GenerateJWTToken(user, roles.ToList());
            LoginResponseDto loginResponseDto = new LoginResponseDto
            {
                Jwt = token,
                Username = user.UserName
            };
            return Ok(loginResponseDto);
        }
    }
}
