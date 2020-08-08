using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    [Table("MovieActor")]
    public class MovieActor : Entity
    {
        public MovieActor()
        {
            id = Id;
        }
        [Key]
        public Guid id { get; set; }
        public Guid movieId { get; set; }
        public Guid actorId { get; set; }
       

    }
}
