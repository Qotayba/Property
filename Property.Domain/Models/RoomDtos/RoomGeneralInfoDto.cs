using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Models.RoomDtos
{
    public class RoomGeneralInfoDto
    {
       
        public int NumberOfBeds { get; set; }
        public int Area { get; set; }
        public bool hasBathroom { get; set; }
    }
}
