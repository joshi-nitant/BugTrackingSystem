using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models.RepositoryClasses
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category AddCategory(Category category)
        {

            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int id)
        {
            Category category = context.Categories.Find(id);

            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return context.Categories;
        }
        public IEnumerable<Category> GetAllCategoryWithSubCategories()
        {
            return context.Categories.Include(category=> category.SubCategories);
        }

        public Category GetCategory(int Id)
        {
            return context.Categories.Find(Id);
        }

        public Category UpdateCategory(Category categoryChanges)
        {
            var category = context.Categories.Attach(categoryChanges);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
