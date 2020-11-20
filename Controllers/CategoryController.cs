using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackingSystem.Models;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        public ICategoryRepository CategoryRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }

        public CategoryController(ICategoryRepository categoryRepository,ISubCategoryRepository subCategoryRepository)
        {
            CategoryRepository = categoryRepository;
            SubCategoryRepository = subCategoryRepository;
        }

        

        [HttpGet]
        [Route("")]
        [Route("Index/{id?}")]
        public IActionResult Index(int? id)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            if (id != null || id != 0)
            {
              
                categoryViewModel.category = CategoryRepository.GetCategory(id);
            }
            
            IEnumerable<Category> categories = CategoryRepository.GetAllCategory();

            categoryViewModel.categories = categories;
            return View(categoryViewModel);
        }

        [HttpPost]
        [Route("")]
        [Route("Index/{id?}")]
        public IActionResult Index(int? id,CategoryViewModel categoryViewModel)
        {
            Category category = categoryViewModel.category;
            if (id==null || id == 0)
            {
                CategoryRepository.AddCategory(category);
            }
            else
            {
                CategoryRepository.UpdateCategory(category);
            }

         
            IEnumerable<Category> categories = CategoryRepository.GetAllCategory();
            categoryViewModel.categories = categories;

            if(id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { id = 0 });
            }
            
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            CategoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("SubCategory/{id}")]
        public IActionResult SubCategory(int id)
        {
            SubCategoryViewModel subCategoryViewModel = new SubCategoryViewModel();
            if (id != 0)
            {

                subCategoryViewModel.subCategories  = SubCategoryRepository.GetAllSubCategoryOfCategory(id);
                subCategoryViewModel.category = CategoryRepository.GetCategory(id);
               
            }
            return View(subCategoryViewModel);
        }
        [HttpPost]
  
        [Route("SubCategory/{id}")]
        public IActionResult SubCategory(SubCategoryViewModel subCategoryViewModel)
        {

            SubCategory subCategory = subCategoryViewModel.subCategory;
            subCategory.CategoryId = subCategoryViewModel.category.CatID;
            SubCategoryRepository.AddSubCategory(subCategory);
            return RedirectToAction("SubCategory");
        }

        [HttpPost]
        [Route("SubCategoryDelete")]
        public IActionResult SubCategoryDelete(SubCategoryViewModel subCategoryViewModel, int id)
        {
            int CatId = subCategoryViewModel.category.CatID;
            SubCategoryRepository .DeleteSubCategory(id);
            return RedirectToAction("SubCategory",new {id = CatId});
        }

    }
}
