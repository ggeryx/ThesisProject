using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Repo
{
    public class TokenRepository : ITokenRepository
    {
        public string GenerateJWTToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pvUTFv8Vzof04Ls6x4Eo2Fmny6lC24V1Dkm4oI1iGkJemDBuct5PpNYk"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "https://localhost:5002/",
                "https://localhost:5002/",
                claims,
                expires: DateTime.Now.AddMinutes(2880), //48 hours LATER : Token refresh policy
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
