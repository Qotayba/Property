using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Domain.Entities
{
    public class ChaletEntity:SeconderyEntity
    {
        

        [ForeignKey("PropertyId")]
        public PropertyEntity? Property { get; set; }
        public int PropertyId { get; set; }
        [Required]
        public bool HavePond { get; set; }
        public bool HaveJacuzzi { get; set; }
        public int PondLength { get; set; }
        public int PondWidth { get; set; }
        public int PondStartHeight { get; set; }
        public int PondEndHeight { get; set; }
    }
}
