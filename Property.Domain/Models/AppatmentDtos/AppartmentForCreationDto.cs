using System.ComponentModel.DataAnnotations;

namespace Property.API.Models.AppatmentDtos
{
    public class AppartmentForCreationDto
    {
        [Required]
        public int Floor { get; set; }
        [Required]
        public bool HaveAnElevator { get; set; }
    }
}
