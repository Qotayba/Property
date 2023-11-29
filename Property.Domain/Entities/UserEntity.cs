using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        public ICollection<PropertyEntity> Properties { get; set; }=new List<PropertyEntity>();

        public ICollection<RoomReservationEntity> RoomReservations{ get; set; } = new List<RoomReservationEntity>();

    }
}
