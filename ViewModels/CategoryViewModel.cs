using BugTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> categories { get; set; }
        public Category category { get; set; }
    }
}
