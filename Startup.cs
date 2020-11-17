using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using BugTrackingSystem.Models.RepositoryClasses;
using Westwind.AspNetCore.LiveReload;

namespace BugTrackingSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLiveReload(config =>
            {
                
            });
            services.AddDbContextPool<AppDbContext>(options=> options.UseSqlServer(_config.GetConnectionString("BugTrackingSystem")));
   
            services.AddMvc(options => options.EnableEndpointRouting = false);
          
            services.AddScoped<IUserRepository, SQLUserRepository>();
            services.AddScoped<IBugRepository, SQLBugRepository>();
            services.AddScoped<IBugCommentRepository, SQLBugCommentRepository>();
            services.AddScoped<IDepartmentRepository, SQLDepartmentRepository>();
            services.AddScoped<ICategoryRepository, SQLCategoryRepository>();
            services.AddScoped<ISubCategoryRepository,SQLSubCategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseLiveReload();
            app.UseStaticFiles();
            app.UseMvc();
        
          
        }
    }
}
