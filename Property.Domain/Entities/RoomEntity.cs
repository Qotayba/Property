using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    public class RoomEntity :BaseEntity
    {

        
       
        [ForeignKey("PropertyId")]
        public PropertyEntity? Property { get; set; }
        public int PropertyId { get; set; }
        public int NumberOfBeds { get; set; }
        public int Area { get; set; }
        public bool hasBathroom { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool ForStudentRent { get; set; } = false;
        public float Price { get; set; } = 0;
        public bool Available { get; set; }=false;

        public ICollection<RoomSuppliesEntity> Rooms { get; set; } = new List<RoomSuppliesEntity>();
        public ICollection<RoomReservationEntity> RoomReservations { get; set; } = new List<RoomReservationEntity>();




    }
}

