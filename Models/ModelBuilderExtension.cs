using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Adding Departments
            List<Department> departments = new List<Department>();

            departments.Add(new Department
            {
                DepartmentId = 1,
                DepartmentName = "BackendDeveloper"
            });
            departments.Add(new Department
            {
                DepartmentId = 2,
                DepartmentName = "FrontendDeveloper"
            });


            modelBuilder.Entity<Department>().HasData(
                departments
            );


            ////Adding Users
            List<User> users = new List<User>();

            users.Add(new User
            {
                UserID = 1,
                UserName = "user1",
                Email = "user1@gmail.com",
                //Dept = departments[0],
                DepartmentId = departments[0].DepartmentId,
                Password = "user1"
            });

            users.Add(new User
            {
                UserID = 2,
                UserName = "user2",
                Email = "user2@gmail.com",
               // Dept = departments[0],
                DepartmentId = departments[0].DepartmentId,
                Password = "user2"
            });

            users.Add(new User
            {
                UserID = 3,
                UserName = "user3",
                Email = "user3@gmail.com",
               // Dept = departments[1],
                DepartmentId = departments[1].DepartmentId,
                Password = "user3"
            });

            modelBuilder.Entity<User>().Property(user => user.IsAdmin).HasDefaultValue(false);
            modelBuilder.Entity<User>().HasData(
                users
            );

            //Adding Category
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                CatID = 1,
                CatName = "Backend",

            });
            categories.Add(new Category
            {
                CatID = 2,
                CatName = "Frontend",

            });

            modelBuilder.Entity<Category>().HasData(categories);

            //Adding Subcategory
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories.Add(new SubCategory
            {
                SubCatID = 1,
                SubCatName = "C#",
                //Cat = categories[0],
                CategoryId = categories[0].CatID
            });

            subCategories.Add(new SubCategory
            {
                SubCatID = 2,
                SubCatName = "HTML",
                //Cat = categories[1],
                CategoryId = categories[1].CatID
            });
            modelBuilder.Entity<SubCategory>().HasData(subCategories);
           
            //Adding Bugs
            List<Bug> bugs = new List<Bug>();

            bugs.Add(new Bug
            {
                BugId = 1,
                Code = @"modelBuilder.Entity<User>().HasData(
                            users
                        ); ",
                Description = "What does this specify. I dont understand why this is needed",
                //Owner = users[0],
                UserId = users[0].UserID,
                IssueDate = DateTime.Now,
                Title = "Issue with modelBuilder",
                //SubCat = subCategories[0],
                SubCategoryId = subCategories[0].SubCatID
            });

            bugs.Add(new Bug
            {
                BugId = 2,
                Code = @"<html>
                            <head> <title> Hello World</title> </head>
                         </html>",
                Description = "Why we write this. I dont understand why this is needed",
                //Owner = users[2],
                UserId = users[2].UserID,
                IssueDate = DateTime.Now,
                Title = "Not understanding the code",
                //SubCat = subCategories[1],
                SubCategoryId = subCategories[1].SubCatID

            });
            modelBuilder.Entity<Bug>().Property(bug => bug.IsSolved).HasDefaultValue(false);
            modelBuilder.Entity<Bug>().HasData(bugs);

            //Adding Bug Comments
            List<BugComment> bugComments = new List<BugComment>();
            bugComments.Add(new BugComment
            {
                BugCommentId = 1,
                BugId = bugs[0].BugId,
                Comment = "This code simply stores the seed data",
                CommentDate = DateTime.Now,
                UserId = users[1].UserID,
            });
            bugComments.Add(new BugComment
            {
                BugCommentId = 2,
                BugId = bugs[1].BugId,
                Comment = "This code is a basic HTML template",
                CommentDate = DateTime.Now,
                UserId = users[0].UserID,
            });
            modelBuilder.Entity<BugComment>().HasData(bugComments);

        }
    }
}
