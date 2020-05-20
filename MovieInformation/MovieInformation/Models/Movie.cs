using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    [Table("Movie")]
    public class Movie: Entity
    {
        public Movie()
        {
            id = Id;

        }
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string imageUrl { get; set; }
        public string author{ get; set; }
        public string times { get; set; }
        public double userScore { get; set; }
        public string trailerUrl { get; set; }
        public string descriptions { get; set; }
        public  DateTime dateRelease { get; set; }
        public DateTime modifiedDate { get; set; }

        public  List<MovieCategory> MovieCategories { get; set; }
        public List<MovieActor> MovieActors{ get; set; }
        
    }
}
