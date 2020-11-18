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
            //List<Bug> bugs = new List<Bug>();

            //bugs.Add(new Bug
            //{
            //    BugId = 1,
            //    Code = @"modelBuilder.Entity<User>().HasData(
            //                users
            //            ); ",
            //    Description = "What does this specify. I dont understand why this is needed",

            //    ApplicationUserId = @"5c0dbaa8-edb8-4adc-b7c8-2b669c572111",
            //    IssueDate = DateTime.Now,
            //    Title = "Issue with modelBuilder",
            //    //SubCat = subCategories[0],
            //    SubCategoryId = subCategories[0].SubCatID
            //});

            //bugs.Add(new Bug
            //{
            //    BugId = 2,
            //    Code = @"<html>
            //                <head> <title> Hello World</title> </head>
            //             </html>",
            //    Description = "Why we write this. I dont understand why this is needed",

            //    ApplicationUserId = @"bc363de9-8494-44c3-b25c-234e056798d3",
            //    IssueDate = DateTime.Now,
            //    Title = "Not understanding the code",
      
            //    SubCategoryId = subCategories[1].SubCatID

            //});
            //modelBuilder.Entity<Bug>().Property(bug => bug.IsSolved).HasDefaultValue(false);
            //modelBuilder.Entity<Bug>().HasData(bugs);

            //Adding Bug Comments
            //List<BugComment> bugComments = new List<BugComment>();
            //bugComments.Add(new BugComment
            //{
            //    BugCommentId = 1,
            //    BugId = bugs[0].BugId,
            //    Comment = "This code simply stores the seed data",
            //    CommentDate = DateTime.Now,
            //    ApplicationUserId = @"bc363de9-8494-44c3-b25c-234e056798d3",
            //});
            //bugComments.Add(new BugComment
            //{
            //    BugCommentId = 2,
            //    BugId = bugs[1].BugId,
            //    Comment = "This code is a basic HTML template",
            //    CommentDate = DateTime.Now,
            //    ApplicationUserId = @"5c0dbaa8-edb8-4adc-b7c8-2b669c572111",
            //});
            //modelBuilder.Entity<BugComment>().HasData(bugComments);

        }
    }
}
