using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.AppatmentDtos
{
    public class AppartmentForCreationDto
    {
       
        public int PropertyId { get; set; }
        public int CreatedByUserId { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public bool HaveAnElevator { get; set; }
    }
}
