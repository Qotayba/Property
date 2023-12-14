using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Entities
{
    public abstract class SeconderyEntity:BaseEntity
    {

        [ForeignKey("CreatedByUserId")]
       
      
        public UserEntity? CreatedByUser { get; set; }
        public int? CreatedByUserId { get; set; }

        [ForeignKey("UpdatedByUserId")]
       
        
        public UserEntity? UpdatedByUser { get; set; }
        
        public int? UpdatedByUserId { get; set; }
    }
}
