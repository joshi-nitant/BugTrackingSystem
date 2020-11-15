using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    interface IBugRepository
    {
        Bug GetBug(int Id);
        IEnumerable<Bug> GetAllBugs();
        Bug AddBug(Bug user);
        Bug UpdateBug(Bug user);
        Bug DeleteBug(int id);
    }
}
