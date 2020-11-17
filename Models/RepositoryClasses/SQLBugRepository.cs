using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLBugRepository : IBugRepository
    {
        private readonly AppDbContext context;

        public SQLBugRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Bug AddBug(Bug bug)
        {
            context.Bugs.Add(bug);
            context.SaveChanges();
            return bug;
        }

        public Bug DeleteBug(int id)
        {
            Bug bug = context.Bugs.Find(id);

            if (bug != null)
            {
                context.Bugs.Remove(bug);
                context.SaveChanges();
            }
            return bug;
        }

        public IEnumerable<Bug> GetAllBugs()
        {
            return context.Bugs;
        }

        public IEnumerable<Bug> GetBugWithComments(int Id)
        {
            return context.Bugs.Where(bug=>bug.BugId==Id).Include(bug=>bug.BugComments);
        }

        public Bug GetBug(int Id)
        {
            return context.Bugs.Find(Id);
        }

        public Bug UpdateBug(Bug bugChanges)
        {
            var bug = context.Bugs.Attach(bugChanges);
            bug.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bugChanges;
        }
    }
}
