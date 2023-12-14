using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.UserDtos
{
    public class UserForCreationDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must only contain numbers.")]
        public string Phone { get; set; }
    }
}
