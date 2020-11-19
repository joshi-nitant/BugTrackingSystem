using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Bug> Bugs { get; set; }
       
        public DbSet<BugComment> BugComments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;

            //}
            modelBuilder.Entity<ApplicationUser>()
                        .HasMany(i => i.UserBugs)
                            .WithOne(i => i.Owner)
                         .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                       .HasMany(i => i.UserComments)
                           .WithOne(i => i.Owner)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bug>()
                      .HasMany(i => i.BugComments)
                          .WithOne(i => i.ParentBug)
                       .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Category>()
                      .HasMany(i => i.SubCategories)
                          .WithOne(i => i.Cat)
                       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
