using Property.Domain.Entities;
using Property.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Property.API.Models
{
    public class PropertyDto
    {

        
        public int Id { get; set; }
        
        
        public int UserId { get; set; }
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
