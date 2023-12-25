using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Property.Domain.Enum;

namespace Property.Domain.Entities
{
    public class RoomSuppliesEntity:BaseEntity
    {
        
        public SupplyStatus SupplyStatus { get; set; }

        [ForeignKey("RoomId")]
        public RoomEntity? Room { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("SupplyId")]
        public SupplyEntity? Supply { get; set; }
        public int SupplyId { get; set; }

    }
}
