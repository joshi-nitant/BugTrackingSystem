using BugTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.ViewModels
{
    public class BugCommentsViewModel
    {
        public Bug bug { get; set; }
        public BugComment bugComment { get; set; }
        public List<BugComment> bugComments { get; set; }
     
    }
}
