using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XinRevolution.Entity.Context;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Repository.Repository;
using XinRevolution.Web.Services.Management;

namespace XinRevolution.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Views/{2}/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/{2}/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Common/{0}.cshtml");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<XinRevolutionDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Database"));
            });

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueRelativeLinkRepository, IssueRelativeLinkRepository>();
            //services.AddScoped<ITagRepository, TagRepository>();

            // Service
            services.AddScoped<UserMnagementService>();
            services.AddScoped<TagManagementService>();
            services.AddScoped<IssueManagementService>();
            services.AddScoped<IssueRelativeLinkManagementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, XinRevolutionDbContext dbContext)
        {
            app.UseHsts();
            app.UseExceptionHandler("/Official/Home/Error");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "Official",
                    areaName: "Official",
                    template: "Official/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "Management",
                    areaName: "Management",
                    template: "Management/{controller=Home}/{action=Login}/{id?}");

                // to be removed after development
                //routes.MapRoute(
                //    name: "Temp",
                //    template: "{area=Management}/{controller=Home}/{action=Login}/{id?}");

                routes.MapRoute(
                    name: "Default",
                    template: "{area=Official}/{controller=Home}/{action=Index}/{id?}");
            });

            dbContext.Database.EnsureCreated();
        }
    }
}
