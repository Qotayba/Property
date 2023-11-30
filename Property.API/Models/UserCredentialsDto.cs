using System.ComponentModel.DataAnnotations;

namespace Property.API.Models
{
    public class UserCredentialsForLoginDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; }=null!;
    }
}
