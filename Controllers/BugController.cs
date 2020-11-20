using BugTrackingSystem.Models;
using BugTrackingSystem.Models.RepositoryClasses;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    [Route("Bugs")]
    public class BugController:Controller
    {
        private readonly IBugRepository _bugRepository;
        private readonly IBugCommentRepository _bugCommentRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public BugController(IBugRepository bugRepository,IBugCommentRepository bugCommentRepository, UserManager<ApplicationUser> userManager,
         SignInManager<ApplicationUser> signInManager)
        {
            _bugRepository = bugRepository;
            this._bugCommentRepository = bugCommentRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("")]
        [Route("Index/{id?}")]
        [HttpGet]
        public ViewResult Index(int? id)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = await userManager.FindByIdAsync(userId);

            //await userManager.AddToRoleAsync(user, "Employee");
            int subCatId = id ?? 0;
            if (subCatId != 0)
            {
                IEnumerable<Bug> bugs = _bugRepository.GetAllBugsWithCategory(subCatId);
                return View(bugs);
            }
            else
            {
                IEnumerable<Bug> bugs = _bugRepository.GetAllBugs();
                return View(bugs);
            }
         
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ViewResult Details(int id)
        {
            BugCommentsViewModel bugCommentsViewModel = new BugCommentsViewModel();
            IEnumerable<Bug> bugs = _bugRepository.GetBugWithComments(id);
            bugCommentsViewModel.bug = bugs.ToList()[0];

            IEnumerable<BugComment> bugComments = bugs.ToList()[0].BugComments;

            List<BugComment> bugCommentsWithUser = new List<BugComment>();
            int i = 0;
            foreach(var bugComment in bugComments)
            {
                var formatedBug = _bugCommentRepository.GetBugComment(bugComment.BugCommentId).ToList()[0];
                formatedBug.Comment = WebUtility.HtmlDecode(formatedBug.Comment);

                bugCommentsWithUser.Add(formatedBug);
            }
            bugCommentsViewModel.bugComments = bugCommentsWithUser;
            return View(bugCommentsViewModel);
        }

        [HttpPost]
        [Route("Details/{id}")]
        public RedirectToActionResult Details(BugCommentsViewModel bugCommentsViewModel)
        {

            var userid = userManager.GetUserId(User);
            BugComment bugComment = new BugComment
            {
                    BugId = bugCommentsViewModel.bug.BugId,
                    Comment = WebUtility.HtmlEncode(bugCommentsViewModel.bugComment.Comment),
                    CommentDate = DateTime.Now,
                    ApplicationUserId = userid,
            };
                
            _bugCommentRepository.AddBugComment(bugComment);
          
            return RedirectToAction();
        }

        [HttpPost]
        [Route("Search")]
        public ViewResult Search(string search)
        {
            
            IEnumerable<Bug> bugs = _bugRepository.GetAllBugs();
            List<Bug> searchedBugs = new List<Bug>();

            if (search == null || search == "")
            {
                return View(bugs);
            }
            search = search.ToLower();
            foreach(Bug bug in bugs)
            {
                string bugTitle = bug.Title.ToLower();
                string bugDescription = bug.Description.ToLower();

                if (search.Equals("solved"))
                {
                    if (bug.IsSolved)
                    {
                        searchedBugs.Add(bug);
                    }

                } else if (search.Equals("unsolved"))
                {
                    if (!bug.IsSolved)
                    {
                        searchedBugs.Add(bug);
                    }

                } else if (search.Equals("all")){
                    searchedBugs.Add(bug);
                } else if (bugTitle.Contains(search) || bugDescription.Contains(search))
                {
                    searchedBugs.Add(bug);
                }
            }
            return View("Index",searchedBugs);
        }


    }
}
