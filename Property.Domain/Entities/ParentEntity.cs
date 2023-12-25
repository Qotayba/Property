using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.Domain.Enum;

namespace Property.Domain.Entities
{
    public abstract class ParentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ItemStatus Status { get; set; } = ItemStatus.Active;

        
    }
}
