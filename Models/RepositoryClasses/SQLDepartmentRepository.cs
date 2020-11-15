using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext context;

        public SQLDepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Department AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

        public Department DeleteDepartment(int id)
        {
            Department department = context.Departments.Find(id);

            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            return department;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return context.Departments;
        }

        public Department GetDepartment(int Id)
        {
            return context.Departments.Find(Id);
        }

        public Department UpdateDepartment(Department departmentChanges)
        {
            var department = context.Departments.Attach(departmentChanges);
            department.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return departmentChanges;
        }
    }
}
