using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Entities
{
    public class RoomReservationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }  
        public UserEntity? User { get; set; }

        [Required]
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public RoomEntity? Room { get; set; }
        
       

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<RoomReservationPaymentEntity> RoomReservationPayments { get; set; } = new List<RoomReservationPaymentEntity>();
    }
}
