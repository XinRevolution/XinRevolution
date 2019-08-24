using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.Models;

namespace XinRevolution.Manager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}


////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Builder;
////using Microsoft.AspNetCore.Hosting;
////using Microsoft.AspNetCore.Http;
////using Microsoft.AspNetCore.HttpsPolicy;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.Extensions.Configuration;
////using Microsoft.Extensions.DependencyInjection;
////using XinRevolution.Entity.Context;

////namespace XinRevolution.Manager
////{
////    public class Startup
////    {
////        public Startup(IConfiguration configuration)
////        {
////            Configuration = configuration;
////        }

////        public IConfiguration Configuration { get; }

////        public void ConfigureServices(IServiceCollection services)
////        {
////            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
////            services.AddDbContext<XinRevolutionDbContext>(options =>
////            {
////                options.UseSqlServer(Configuration.GetConnectionString("Database"));
////            });
////        }

////        public void Configure(IApplicationBuilder app, XinRevolutionDbContext dbContext)
////        {
////            app.UseExceptionHandler("/Home/Error");
////            app.UseHsts();
////            app.UseHttpsRedirection();
////            app.UseStaticFiles();
////            app.UseCookiePolicy();
////            app.UseMvc(routes =>
////            {
////                routes.MapRoute(
////                    name: "default",
////                    template: "{controller=Home}/{action=Login}/{id?}");
////            });

////            dbContext.Database.EnsureCreated();
////        }
////    }
////}