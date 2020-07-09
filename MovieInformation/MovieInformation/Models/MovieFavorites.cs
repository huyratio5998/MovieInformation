using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    public class MovieFavorites : Entity
    {
        public MovieFavorites()
        {
            id = Id;
        }
        [Key]
        public Guid id { get; set; }
        public string movieId { get; set; }
        public bool isFavorites { get; set; }
        public string userName{ get; set; }        
    }
}
