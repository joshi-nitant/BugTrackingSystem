using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.ViewModels
{
    public class MyBugAddViewModel
    {
        public Bug bug { get; set; }
        public Category category { get; set; }
        public SubCategory subCategory { get; set; }
        public IEnumerable<Bug> bugs { get; set; }
    }
}
