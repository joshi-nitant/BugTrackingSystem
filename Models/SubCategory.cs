using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCatID { get; set; }
        
        [Required]
        public string SubCatName { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Cat { get; set; }
       
        public IList<Bug> CategoryBugs { get; set; }
     }
}
