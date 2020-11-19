using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public interface ICategoryRepository
    {
        Category GetCategory(int? Id);
        IEnumerable<Category> GetAllCategory();
        IEnumerable<Category> GetAllCategoryWithSubCategories();
        Category AddCategory(Category user);
        Category UpdateCategory(Category user);
        Category DeleteCategory(int id);
    }
}
