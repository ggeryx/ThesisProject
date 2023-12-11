namespace AuthService.Models.Dtos
{
    public class LoginResponseDto
    {
        public string Jwt { get; set; }
        public string Username { get; set; }
    }
}
