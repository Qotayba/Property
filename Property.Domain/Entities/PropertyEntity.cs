
using Property.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Property.Domain.Entities
{
    public class PropertyEntity :BaseEntity
    {
        
        [ForeignKey("PropertyOwnerId")]
        public UserEntity? Owner { get; set; }
        public int PropertyOwnerId { get; set; }
        public PropertyType Type { get; set; }
        public int? Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ForWhat { get; set; }
        public string? PayMethod { get; set; }
        public int TotalArea { get; set; }
        public int NumberOfRooms { get; set; }
        public AppartmentEntity Appartment { get; set; }
        public ChaletEntity Chalet { get; set; }
        public ICollection<RoomEntity> Rooms { get; set; }=new List<RoomEntity>();
    }
}
