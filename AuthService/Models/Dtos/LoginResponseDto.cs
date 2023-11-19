namespace AuthService.Models.Dtos
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string Username { get; set; }
    }
}
