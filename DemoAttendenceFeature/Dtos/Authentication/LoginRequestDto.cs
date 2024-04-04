using System.ComponentModel.DataAnnotations;

namespace DemoAttendenceFeature.Dtos.Authentication
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
