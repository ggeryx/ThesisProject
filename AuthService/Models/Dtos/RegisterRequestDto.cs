using System.ComponentModel.DataAnnotations;

namespace AuthService.Models.Dtos
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
