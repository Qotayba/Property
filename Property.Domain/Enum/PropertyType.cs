using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Property.Domain.Enum
{
    public enum PropertyType
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "Apartment")]
        Apartment,
        [Display(Name = "Chalet")]
        Chalet
    }
}
