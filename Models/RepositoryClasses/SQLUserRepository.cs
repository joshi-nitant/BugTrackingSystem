using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            User user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;

        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int Id)
        {
            return context.Users.Find(Id);
        }

        public User UpdateUser(User userChanges)
        {
            var user = context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
