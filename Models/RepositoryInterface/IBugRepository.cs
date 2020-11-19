using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public interface IBugRepository
    {
        IEnumerable<Bug> GetBug(int Id);
        IEnumerable<Bug> GetAllBugs();
        IEnumerable<Bug> GetAllBugsWithCategory(int id);
        IEnumerable<Bug> GetAllBugsOfUser(string id);

        IEnumerable<Bug> GetBugWithComments(int Id);
        Bug AddBug(Bug user);
        Bug UpdateBug(Bug user);
        Bug DeleteBug(int id);
    }
}
