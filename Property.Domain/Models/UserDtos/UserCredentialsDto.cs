using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.UserDtos
{
    public class UserCredentialsForLoginDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; }=null!;
    }
}
