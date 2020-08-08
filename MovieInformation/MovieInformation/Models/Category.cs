using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    [Table("Category")]
    public class Category : Entity
    {
        public Category()
        {
            id = Id;

        }
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        private List<MovieCategory> movieCategories { get; set; }
    }
}
