using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLBugCommentRepository : IBugCommentRepository
    {
        private readonly AppDbContext context;

        public SQLBugCommentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public BugComment AddBugComment(BugComment bugComment)
        {
            context.BugComments.Add(bugComment);
            context.SaveChanges();
            return bugComment;
        }

        public BugComment DeleteBugComment(int id)
        {
            BugComment bugComment = context.BugComments.Find(id);

            if (bugComment != null)
            {
                context.BugComments.Remove(bugComment);
                context.SaveChanges();
            }
            return bugComment;
        }

        public IEnumerable<BugComment> GetAllBugComment()
        {
            return context.BugComments;
        }

        public IEnumerable<BugComment> GetBugComment(int Id)
        {
            return context.BugComments.Where(bugComment => bugComment.BugCommentId == Id).Include(bugComment => bugComment.Owner);
        }

      

        public BugComment UpdateBugComment(BugComment bugComment)
        {
            var bug = context.BugComments.Attach(bugComment);
            bug.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bugComment;
        }

    }
}
