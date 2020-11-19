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
    }
}
