using Property.Domain.Entities;
using Property.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Property.Domain.Models.PropertyDtos
{
    public class PropertyForUpdateDto
    {
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }= DateTime.Now;
        
        public PropertyType Type { get; set; }
        public int? Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ForWhat { get; set; }
        public string? PayMethod { get; set; }
        public int TotalArea { get; set; }
        public int NumberOfRooms { get; set; }
      
    }
}
