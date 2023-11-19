using Microsoft.AspNetCore.Identity;

namespace AuthService.Repo
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
