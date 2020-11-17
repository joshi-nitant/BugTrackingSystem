using BugTrackingSystem.Models;
using BugTrackingSystem.Models.RepositoryClasses;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    [Route("Bugs")]
    public class BugController:Controller
    {
        private readonly IBugRepository _bugRepository;
        private readonly IBugCommentRepository _bugCommentRepository;

        public BugController(IBugRepository bugRepository,IBugCommentRepository bugCommentRepository)
        {
            _bugRepository = bugRepository;
            this._bugCommentRepository = bugCommentRepository;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public ViewResult Index()
        {
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

            BugComment bugComment = new BugComment
            {
                    BugId = bugCommentsViewModel.bug.BugId,
                    Comment = bugCommentsViewModel.bugComment.Comment,
                    CommentDate = DateTime.Now,
                    UserId = 1,
             };
                
            _bugCommentRepository.AddBugComment(bugComment);
            
            
            return RedirectToAction();
        }

    }
}
