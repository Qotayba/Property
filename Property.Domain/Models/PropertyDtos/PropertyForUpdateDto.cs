using Property.Domain.Entities;
using Property.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Property.Domain.Models.PropertyDtos
{
    public class PropertyForUpdateDto
    {
        public int UpdatedByUserId { get; set; }
        [Required]
        public PropertyType Type { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ForWhat { get; set; }
        [Required]
        public string? PayMethod { get; set; }
        [Required]
        public int TotalArea { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
      
    }
}
