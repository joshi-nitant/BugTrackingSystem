using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class BugComment
    {
        [Key]
        public int BugCommentId { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Comment is too short. Please describe more")]
        public string Comment { get; set; }
        
        [Required]
        public int BugId { get; set; }
        public Bug ParentBug { get; set; }
        
        [Required]
        public DateTime CommentDate { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
