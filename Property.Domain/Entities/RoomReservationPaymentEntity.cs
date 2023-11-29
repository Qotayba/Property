using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Property.Domain.Enum;

namespace Property.Domain.Entities
{
    public class RoomReservationPaymentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime PaymentTime { get; set; }

        public int AmountOfPayment { get; set; }

        [ForeignKey("RoomReservationId")]
        [Required]
        public int RoomReservationId { get; set; }
        public RoomReservationEntity? RoomReservation { get; set; }
       

        [Required]
        public PayMethod PayMethod { get; set; }
    }
}
