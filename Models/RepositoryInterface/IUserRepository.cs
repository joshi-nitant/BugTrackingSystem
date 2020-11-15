using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    interface IUserRepository
    {
        User GetUser(int Id);
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
