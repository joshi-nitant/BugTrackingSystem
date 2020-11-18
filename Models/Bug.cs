using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class Bug
    {
        [Key]
        public int BugId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Description must be more than 10 characters")]
        public string Description { get; set; }
       
      
        public string Code { get; set; }
        [Required]
        public int  SubCategoryId { get; set; }
        public SubCategory SubCat { get; set; }
        
      
        public string ApplicationUserId { get; set; }
        public ApplicationUser Owner { get; set; }
       
      
        public DateTime IssueDate { get; set; }
       
        public bool IsSolved { get; set; }
       
        public IList<BugComment> BugComments { get; set; }
    }
}
