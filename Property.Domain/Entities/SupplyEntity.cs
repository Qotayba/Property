using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    public class SupplyEntity
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       [Required]
       public string Name { get; set; }
       [Required]
       public string Price { get; set; }
       public ICollection<RoomSuppliesEntity> Rooms { get; set; } = new List<RoomSuppliesEntity>();

    }
}
