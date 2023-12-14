using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    public class SupplyEntity:SeconderyEntity
    {
       
       [Required]
       public string Name { get; set; }
       [Required]
       public string Price { get; set; }
       public ICollection<RoomSuppliesEntity> Rooms { get; set; } = new List<RoomSuppliesEntity>();

    }
}
