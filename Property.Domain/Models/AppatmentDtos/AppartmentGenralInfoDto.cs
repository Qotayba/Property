using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.AppatmentDtos
{
    public class AppartmentGenralInfoDto
    { 
    public int Floor { get; set; }
    
    public bool HaveAnElevator { get; set; }
    }
}
