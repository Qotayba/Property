
using Property.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Property.Domain.Entities
{
    public class PropertyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [ForeignKey("UserId")]
        public UserEntity? Owner { get; set; }
        public int UserId { get; set; }
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
        public List<RoomEntity> Rooms { get; set; }
    }
}
