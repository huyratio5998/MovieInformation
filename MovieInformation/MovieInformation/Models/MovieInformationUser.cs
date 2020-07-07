using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MovieInformation.Models
{
    public class MovieInformationUser : IdentityUser
    {
        public string Guest_session_id { get; set; }
        public string Birthday { get; set; }
        public string Picture { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }        
    }
}
