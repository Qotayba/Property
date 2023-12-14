using Property.Domain.Entities;
using Property.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Property.Domain.Models.RoomDtos;
using Property.Domain.Models.AppatmentDtos;

namespace Property.Domain.Models.PropertyDtos
{
    public class PropertyAppartmentRoomsDto
    {
        
        public int Id { get; set; }
        
        
       
        public PropertyType Type { get; set; }
        public int? Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ForWhat { get; set; }
        public string? PayMethod { get; set; }
        public int TotalArea { get; set; }
        public int NumberOfRooms { get; set; }
        public AppartmentGenralInfoDto Appartment { get; set; }

        public ICollection<RoomGeneralInfoDto> Rooms { get; set; }= new List<RoomGeneralInfoDto>();

    }
}
