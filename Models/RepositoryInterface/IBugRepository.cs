using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public interface IBugRepository
    {
        Bug GetBug(int Id);
        IEnumerable<Bug> GetAllBugs();
        IEnumerable<Bug> GetBugWithComments(int Id);
        Bug AddBug(Bug user);
        Bug UpdateBug(Bug user);
        Bug DeleteBug(int id);
    }
}
