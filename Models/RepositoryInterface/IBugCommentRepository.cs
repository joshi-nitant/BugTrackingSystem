using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public interface IBugCommentRepository
    {
        BugComment GetBugComment(int Id);
        IEnumerable<BugComment> GetAllBugComment();
        BugComment AddBugComment(BugComment user);
        BugComment UpdateBugComment(BugComment user);
        BugComment DeleteBugComment(int id);
    }
}
