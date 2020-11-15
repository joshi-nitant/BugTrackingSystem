using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
     
        [Required]
        [Range(5,70, ErrorMessage = "Name must be between 5 to 70 characters")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$",ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }


        [Required]
        [ForeignKey("Dept")]
        public int DepartmentId { get; set; }
        
        public virtual Department Dept { get; set; }

        [Required]
        public string Password { get; set; }
        
        public bool IsAdmin { get; set; }
        
        public IList<Bug> UserBugs { get; set; }
        
        public IList<BugComment> UserComments { get; set; }
    }
}
