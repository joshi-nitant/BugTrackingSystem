using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackingSystem.Models;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackingSystem.Controllers
{
    [Route("MyBugs")]
    public class MyBugsController : Controller
    {
        public IBugRepository BugRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        private readonly UserManager<ApplicationUser> userManager;

        public MyBugsController(UserManager<ApplicationUser> userManager, IBugRepository bugRepository, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
        {
            this.userManager = userManager;
            BugRepository = bugRepository;
            CategoryRepository = categoryRepository;
            SubCategoryRepository = subCategoryRepository;
        }

        [HttpGet]
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            MyBugAddViewModel myBugAddViewModel = new MyBugAddViewModel();
            var id = userManager.GetUserId(User);
            IEnumerable<Bug> bugs = BugRepository.GetAllBugsOfUser(id);
            List<Category> categories = CategoryRepository.GetAllCategory().ToList();
            categories = (from category in categories select category).ToList();
            categories.Insert(0, new Category
            {
                CatID = 0,
                CatName = "Select Project",
            });
            ViewBag.ListOfCategory = categories;
            myBugAddViewModel.bugs = bugs;
          
            return View(myBugAddViewModel);
        }

        [HttpPost]
        [Route("Index")]
        [Route("")]
        public IActionResult Index(MyBugAddViewModel myBugAddViewModel)
        {

            if (ModelState.IsValid)
            {
                if (myBugAddViewModel.category.CatID == 0)
                {
                    ModelState.AddModelError("", "Select Category");
                    return View(myBugAddViewModel);
                }
                var SubCategoryID = HttpContext.Request.Form["SubCatId"].ToString();
                if (SubCategoryID == "0")
                {
                    ModelState.AddModelError("", "Select SubCategory");
                    return View(myBugAddViewModel);
                }

                Bug bug = myBugAddViewModel.bug;
                bug.SubCategoryId = Int32.Parse(SubCategoryID);
                bug.ApplicationUserId = userManager.GetUserId(User);
                bug.IssueDate = DateTime.Now;

                BugRepository.AddBug(bug);
                return RedirectToAction("Index");
            }
            var id = userManager.GetUserId(User);
            IEnumerable<Bug> bugs = BugRepository.GetAllBugsOfUser(id);
            myBugAddViewModel.bugs = bugs;
            List<Category> categories = CategoryRepository.GetAllCategory().ToList();
            categories = (from category in categories select category).ToList();
            categories.Insert(0, new Category
            {
                CatID = 0,
                CatName = "Select Category",
            });
            ViewBag.ListOfCategory = categories;
            return View(myBugAddViewModel);

        }

        //[HttpGet]
        //[Route("Add")]
        //public IActionResult Add()
        //{

        //    List<Category> categories = CategoryRepository.GetAllCategory().ToList();
        //    categories = (from category in categories select category).ToList();
        //    categories.Insert(0, new Category
        //    {
        //        CatID = 0,
        //        CatName = "Select Category",
        //    });
        //    ViewBag.ListOfCategory = categories;

        //    return View();
        //}

        //[HttpPost]
        //[Route("Add")]
        //public IActionResult Add(MyBugAddViewModel myBugAddViewModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (myBugAddViewModel.category.CatID == 0)
        //        {
        //            ModelState.AddModelError("", "Select Category");
        //            return View(myBugAddViewModel);
        //        }
        //        var SubCategoryID = HttpContext.Request.Form["SubCatId"].ToString();
        //        if(SubCategoryID == "0")
        //        {
        //            ModelState.AddModelError("", "Select SubCategory");
        //            return View(myBugAddViewModel);
        //        }

        //        Bug bug = myBugAddViewModel.bug;
        //        bug.SubCategoryId =  Int32.Parse(SubCategoryID);
        //        bug.ApplicationUserId = userManager.GetUserId(User);
        //        bug.IssueDate = DateTime.Now;

        //        BugRepository.AddBug(bug);
        //        return RedirectToAction("Index");
        //    }
        //    List<Category> categories = CategoryRepository.GetAllCategory().ToList();
        //    categories = (from category in categories select category).ToList();
        //    categories.Insert(0, new Category
        //    {
        //        CatID = 0,
        //        CatName = "Select Category",
        //    });
        //    ViewBag.ListOfCategory = categories;
        //    return View(myBugAddViewModel);

        //}

        [HttpGet]
        [Route("EditBug/{BugId}")]
        public IActionResult EditBug(int BugId)
        {
            MyBugEditViewModel myBugEditViewModel = new MyBugEditViewModel();

            IEnumerable<Bug> bugs = BugRepository.GetBug(BugId);
            var bug = bugs.First();
            myBugEditViewModel.bug = bug;


            List<Category> categories = CategoryRepository.GetAllCategory().ToList();
            ViewBag.ListOfCategory = categories;
            myBugEditViewModel.category = bug.SubCat.Cat;

            List<SubCategory> subCategories = SubCategoryRepository.GetAllSubCategory().ToList();
            subCategories = (from subCategory in subCategories where subCategory.CategoryId == bug.SubCat.Cat.CatID select subCategory).ToList();
            ViewBag.ListOfSubCategory = subCategories;
            myBugEditViewModel.subCategory = bug.SubCat;
            
            var id = userManager.GetUserId(User);
            IEnumerable<Bug> bugsList = BugRepository.GetAllBugsOfUser(id);
            myBugEditViewModel.bugs = bugsList;
            return View(myBugEditViewModel);
        }

        [HttpPost]
        [Route("EditBug/{BugId}")]
        public IActionResult EditBug(int BugId,MyBugEditViewModel myBugEditViewModel)
        {
            if (ModelState.IsValid)
            {
                
                var SubCategoryID = HttpContext.Request.Form["SubCatId"].ToString();
                if (SubCategoryID == "0")
                {
                    ModelState.AddModelError("", "Select SubCategory");
                    return View(myBugEditViewModel);
                }

                Bug newBug = myBugEditViewModel.bug;
                newBug.SubCategoryId = Int32.Parse(SubCategoryID);
                
                BugRepository.UpdateBug(newBug);
                return RedirectToAction("Index");
            }
            IEnumerable<Bug> bugs = BugRepository.GetBug(BugId);
            var bug = bugs.First();
            myBugEditViewModel.bug = bug;

            List<Category> categories = CategoryRepository.GetAllCategory().ToList();
            ViewBag.ListOfCategory = categories;
            myBugEditViewModel.category = bug.SubCat.Cat;

            List<SubCategory> subCategories = SubCategoryRepository.GetAllSubCategory().ToList();
            subCategories = (from subCategory in subCategories where subCategory.CategoryId==bug.SubCat.Cat.CatID select subCategory).ToList();
            ViewBag.ListOfSubCategory = subCategories;
            myBugEditViewModel.subCategory = bug.SubCat;

            var id = userManager.GetUserId(User);
            IEnumerable<Bug> bugsList = BugRepository.GetAllBugsOfUser(id);
            myBugEditViewModel.bugs = bugsList;
            return View(myBugEditViewModel);
        }

        [HttpPost]
        [Route("Delete/{BugId}")]
        public IActionResult DeleteBug(int BugId)
        {

            BugRepository.DeleteBug(BugId);
            return RedirectToAction("Index");
     
        }

        [HttpGet]
        [Route("GetSubCategory/{CategoryId}")]
        public JsonResult GetSubCategory(int CategoryId)
        {
            List<SubCategory> subCategories = SubCategoryRepository.GetAllSubCategory().ToList();
            subCategories = (from subCategory in subCategories where subCategory.CategoryId == CategoryId select subCategory).ToList();
            subCategories.Insert(0, new SubCategory
            {
                SubCatID = 0,
                SubCatName = "Select Sub Category",
            });
            return Json(new SelectList(subCategories, "SubCatID", "SubCatName"));
        }
    }
}
