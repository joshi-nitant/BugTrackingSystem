using BugTrackingSystem.Models;
using BugTrackingSystem.Models.RepositoryClasses;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("Index")]
        [HttpGet]
        public ViewResult Index()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = await userManager.FindByIdAsync(userId);

            //await userManager.AddToRoleAsync(user, "Employee");
            IEnumerable<Bug> bugs = _bugRepository.GetAllBugs();
            return View(bugs);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ViewResult Details(int id)
        {
            BugCommentsViewModel bugCommentsViewModel = new BugCommentsViewModel();
            IEnumerable<Bug> bugs = _bugRepository.GetBugWithComments(id);
            bugCommentsViewModel.bug = bugs.ToList()[0];
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
                    Comment = bugCommentsViewModel.bugComment.Comment,
                    CommentDate = DateTime.Now,
                    ApplicationUserId = userid,
            };
                
            _bugCommentRepository.AddBugComment(bugComment);
          
            return RedirectToAction();
        }
      

    }
}
