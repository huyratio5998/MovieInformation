using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    [Table("Actor")]
    public class Actor : Entity
    {
        public Actor()
        {
            id = Id;
        }
        [Key]
        public Guid id { get; set; }
        public string fullName { get; set; }
        public string nickName { get; set; }
        public string placeOfBirth { get; set; }
        public Gender gender { get; set; }
        public DateTime? birthDay { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
        public List<MovieActor> MovieActors { get; set; }
    }

    public enum Gender
    {
        Male=1,
        Female=0
    }
}
