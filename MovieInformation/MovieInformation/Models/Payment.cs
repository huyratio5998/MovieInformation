using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{    
    [Table("Payment")]
    public class Payment : Entity
    {
        public Payment()
        {
            id = Id;
        }
        [Key]
        public Guid id { get; set; }
        public Guid userId{ get; set; }
        public string amount { get; set; }
        public string currency { get; set; }       
        public DateTime expireDate { get; set; }              
    }
}
