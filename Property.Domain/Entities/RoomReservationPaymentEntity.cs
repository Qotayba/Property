using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Property.Domain.Enum;

namespace Property.Domain.Entities
{
    public class RoomReservationPaymentEntity :SeconderyEntity
    {
       
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
