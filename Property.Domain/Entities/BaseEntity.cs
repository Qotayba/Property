using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Entities
{
    public abstract class BaseEntity:ParentEntity
    {

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}
