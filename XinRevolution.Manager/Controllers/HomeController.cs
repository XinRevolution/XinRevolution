//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using XinRevolution.Manager.Models;

//namespace XinRevolution.Manager.Controllers
//{
//    public class HomeController : Controller
//    {
//        public IActionResult Login()
//        {
//            return View();
//        }
//    }
//}


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

//    using Microsoft.AspNetCore.Http;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using XinRevolution.Manager.Models;

//namespace XinRevolution.Manager.Service
//{
//    public class AzureBlobService
//    {
//        private readonly string _connectionString;

//        public AzureBlobService(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("Blob");
//        }

//        public OperationResult<string> Save(string containerName, IFormFile file)
//        {
//            var result = new OperationResult<string>();
//            var stream = new MemoryStream();

//            try
//            {
//                if (file == null || file.Length <= 0 || string.IsNullOrEmpty(file.FileName))
//                    throw new Exception($"檔案異常 (無上傳檔案或檔案大小為 0)");

//                var fileName = GetFileName(file.FileName);
//                var storageAccount = CloudStorageAccount.Parse(_connectionString);
//                var blobClient = storageAccount.CreateCloudBlobClient();

//                var blobContainer = blobClient.GetContainerReference(containerName.ToLower());
//                blobContainer.CreateIfNotExists();

//                var permision = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob };
//                blobContainer.SetPermissions(permision);

//                file.CopyTo(stream);

//                var blockBlob = blobContainer.GetBlockBlobReference(fileName);
//                blockBlob.UploadFromStream(stream);

//                stream.Dispose();

//                result.Status = true;
//                result.Message = $"儲存成功";
//                result.Data = blockBlob.Uri.AbsoluteUri;
//            }
//            catch (Exception ex)
//            {
//                stream.Dispose();

//                result.Status = false;
//                result.Message = ex.Message;
//                result.Data = null;
//            }

//            return result;
//        }

//        public OperationResult Remove(string resourceUrl)
//        {
//            OperationResult result = new OperationResult();

//            try
//            {
//                var blockBlob = new CloudBlockBlob(new Uri(resourceUrl));
//                blockBlob.Delete();

//                result.Status = true;
//                result.Message = $"刪除成功";
//            }
//            catch (Exception ex)
//            {
//                result.Status = false;
//                result.Message = ex.Message;
//            }

//            return result;
//        }

//        private string GetFileName(string fileName)
//        {
//            return $"{Path.GetFileName(fileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{Path.GetExtension(fileName)}";
//        }
//    }
//}

