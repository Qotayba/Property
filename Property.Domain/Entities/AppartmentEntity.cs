using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    public class AppartmentEntity :BaseEntity
    {
        
        [ForeignKey("PropertyId")]
        public PropertyEntity? Property { get; set; }
        public int PropertyId { get; set; }
        public int Floor { get; set; }
        public bool HaveAnElevator { get; set; }
    }
}
