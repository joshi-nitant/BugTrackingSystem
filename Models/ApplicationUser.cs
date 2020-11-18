using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class ApplicationUser: IdentityUser
    { 
        
        public string Name { get; set; }

        public Department Dept { get; set; }

 
        public IList<Bug> UserBugs { get; set; }
        
        public IList<BugComment> UserComments { get; set; }
    }
}
