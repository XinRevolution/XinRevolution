using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Web.Models.ViewModel.Management;

namespace XinRevolution.Web.Services.Management
{
    public class FileManagementService
    {
        public IHostingEnvironment _enviroment;

        public FileManagementService(IHostingEnvironment enviroment)
        {
            _enviroment = enviroment;
        }

        public Result<string> Save(string virtualFolder, IFormFile file)
        {
            Result<string> result = new Result<string>();

            try
            {
                if (string.IsNullOrEmpty(folderPath))
                    throw new Exception($"資料夾路徑異常");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                
                var fileName = $"{new Guid().ToString()}.{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(folderPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                result.Status = true;
                result.Message = "儲存成功";
                result.Data = fileName;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public Result<string> Remove(string filePath)
        {
            Result<string> result = new Result<string>();

            try
            {
                File.Delete(filePath);
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = filePath;
            }

            return result;
        }
    }
}
