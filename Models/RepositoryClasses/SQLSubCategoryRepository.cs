using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLSubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext context;

        public SQLSubCategoryRepository(AppDbContext context )
        {
            this.context = context;
        }

        public SubCategory AddSubCategory(SubCategory subCategory)
        {
            context.SubCategories.Add(subCategory);
            context.SaveChanges();
            return subCategory;
        }

        public SubCategory DeleteSubCategory(int id)
        {
            SubCategory subCategory = context.SubCategories.Find(id);

            if (subCategory != null)
            {
                context.SubCategories.Remove(subCategory);
                context.SaveChanges();
            }
            return subCategory;
        }

        public IEnumerable<SubCategory> GetAllSubCategory()
        {
            return context.SubCategories.Include(subCategory=>subCategory.Cat);
        }

        public IEnumerable<SubCategory> GetAllSubCategoryOfCategory(int id)
        {
            return context.SubCategories.Where(subCategory=> subCategory.CategoryId==id).Include(subCategory => subCategory.Cat);
        }

        public SubCategory GetSubCategory(int? Id)
        {
            return context.SubCategories.Find(Id);
        }

        public SubCategory UpdateSubCategory(SubCategory subCategoryChanges)
        {
            var subCategory = context.SubCategories.Attach(subCategoryChanges);
            subCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return subCategoryChanges;
        }
    }
}
