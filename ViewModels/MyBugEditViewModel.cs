using BugTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.ViewModels
{
    public class MyBugEditViewModel
    {
        public Bug bug { get; set; }
        public Category category { get; set; }
        public SubCategory subCategory { get; set; }
    }
      
}
