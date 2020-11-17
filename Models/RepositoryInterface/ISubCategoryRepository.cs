using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public interface ISubCategoryRepository
    {
        SubCategory GetSubCategory(int Id);
        IEnumerable<SubCategory> GetAllSubCategory();
        SubCategory AddSubCategory(SubCategory user);
        SubCategory UpdateSubCategory(SubCategory user);
        SubCategory DeleteSubCategory(int id);
    }
}
