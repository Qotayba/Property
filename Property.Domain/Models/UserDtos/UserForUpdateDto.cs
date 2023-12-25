using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Models.UserDtos
{
    public class UserForUpdateDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

       
        [MaxLength(13)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must only contain numbers.")]
        public string phone { get; set; }
    }
}
