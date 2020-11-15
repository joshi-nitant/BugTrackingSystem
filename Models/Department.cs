using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public IList<User> DepartmentUsers { get; set; }
    }
}
