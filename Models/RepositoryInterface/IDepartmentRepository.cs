using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    interface IDepartmentRepository
    {
        Department GetDepartment(int Id);
        IEnumerable<Department> GetAllDepartment();
        Department AddDepartment(Department user);
        Department UpdateDepartment(Department user);
        Department DeleteDepartment(int id);
    }
}
