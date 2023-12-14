using Property.Domain.Models.AppatmentDtos;
using Property.Domain.Models.RoomDtos;
using Property.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.PropertyDtos
{
    public class PropertyForCreatAppartmentDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public PropertyType Type { get; } = PropertyType.Apartment;
        [Required]
        public int? Price { get; set; }
        [Required]
        public string Location { get; set; }
        public string Description { get; set; }
        [Required]
        public string ForWhat { get; set; }
        public string? PayMethod { get; set; }
        public int TotalArea { get; set; }
        
        [Required]
        public AppartmentForCreationDto Appartment { get; set; }
        public ICollection <RoomForCreationDto> Rooms { get; set; } = new List<RoomForCreationDto>();
        
    }
}

