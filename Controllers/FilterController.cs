using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    [Route("Filter")]
    public class FilterController : Controller
    {
        public ISubCategoryRepository SubCategoryRepository { get; }

        public FilterController(ISubCategoryRepository subCategoryRepository)
        {
            SubCategoryRepository = subCategoryRepository;
        }

        

        [HttpGet]
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            IEnumerable<SubCategory> subCategories = SubCategoryRepository.GetAllSubCategory();
            return View(subCategories);
        }
        [HttpPost]
        [Route("Search")]
        public ViewResult Search(string search)
        {
            IEnumerable<SubCategory> subCategories = SubCategoryRepository.GetAllSubCategory();
            if (search == null || search == "")
            {
                return View("Index",subCategories);
            }
            search = search.ToLower();
            List<SubCategory> seachedSubCategory = new List<SubCategory>();
            foreach(SubCategory subCategory in subCategories)
            {
                string categoryName = subCategory.Cat.CatName.ToLower();
                if (categoryName.Contains(search))
                {
                    seachedSubCategory.Add(subCategory);
                }
            }
            return View("Index",seachedSubCategory);
        }
    }
}
