using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Models.AppatmentDtos
{
    public class AppartmentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
        public int PropertyId { get; set; }
        public int Floor { get; set; }
        public bool HaveAnElevator { get; set; }
    }
}
