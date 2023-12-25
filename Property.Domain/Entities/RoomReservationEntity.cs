using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Entities
{
    public class RoomReservationEntity:BaseEntity
    {

        [ForeignKey("userfId")]
        public UserEntity userf { get; set; }
        public int userfId { get; set; }
        
        [Required]
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public RoomEntity? Room { get; set; }
        
       

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<RoomReservationPaymentEntity> RoomReservationPayments { get; set; } = new List<RoomReservationPaymentEntity>();
    }
}
