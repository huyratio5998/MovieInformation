using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Models
{
    public class Entity
    {
        public Guid Id { get; }
        public  DateTime CreatedDate { get; set; }

        public Entity()
        {
            Id=Guid.NewGuid();
            CreatedDate = DateTime.Now.ToUniversalTime();
            
        }
        
    }
}
