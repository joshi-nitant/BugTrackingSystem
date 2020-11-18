using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

     
        public string CatName { get; set; }
        
        public IList<SubCategory> SubCategories { get; set; }
    }
}
