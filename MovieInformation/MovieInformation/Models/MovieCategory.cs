using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    [Table("MovieCategory")]
    public class MovieCategory : Entity
    {
        public MovieCategory()
        {
            id = Id;
        }
        [Key]
        public Guid id { get; set; }
        public Guid moviesId { get; set; }
        public Guid categorieId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
