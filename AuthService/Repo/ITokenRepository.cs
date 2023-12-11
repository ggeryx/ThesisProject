using Microsoft.AspNetCore.Identity;

namespace AuthService.Repo
{
    public interface ITokenRepository
    {
        string GenerateJWTToken(IdentityUser user, List<string> roles);
    }
}
