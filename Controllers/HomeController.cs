using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackingSystem.Models;
using BugTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    [Route("")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

       

        public HomeController(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager; 
            this.roleManager = roleManager;
        }

        [Route("")]
        [Route("Index")]
        [Route("Login")]
        [HttpGet]
        public IActionResult Index()
        {
            //IdentityRole identityRole = new IdentityRole
            //{
            //    Name = model.RoleName
            //};

            //// Saves the role in the underlying AspNetRoles table
            //IdentityResult result = await roleManager.CreateAsync(identityRole);
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("Index")]
        [Route("Login")]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "bug");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
