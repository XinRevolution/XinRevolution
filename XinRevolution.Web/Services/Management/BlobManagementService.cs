using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Web.Models.Management;

namespace XinRevolution.Web.Services.Management
{
    public class BlobManagementService
    {
        private readonly string _connectionString;

        public BlobManagementService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public OperationResult<string> Save(string containerName, IFormFile file)
        {
            var result = new OperationResult<string>();

            try
            {
                if (file == null || file.Length <= 0 || string.IsNullOrEmpty(file.FileName))
                    throw new Exception($"檔案異常 (無上傳檔案或檔案大小為 0)");

                var fileName = GetFileName(file.FileName);
                var storageAccount = CloudStorageAccount.Parse(_connectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(containerName.ToLower());
                blobContainer.CreateIfNotExists();

                var permision = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob };
                blobContainer.SetPermissions(permision);

                var stream = new MemoryStream();
                file.CopyTo(stream);

                var blockBlob = blobContainer.GetBlockBlobReference(fileName);
                blockBlob.UploadFromStream(stream);

                result.Status = true;
                result.Message = $"儲存成功";
                result.Data = blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public OperationResult<string> Remove(string resourceUrl)
        {
            OperationResult<string> result = new OperationResult<string>();

            try
            {
                var blockBlob = new CloudBlockBlob(new Uri(resourceUrl));
                blockBlob.Delete();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        private string GetFileName(string fileName)
        {
            return $"{Path.GetFileName(fileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{Path.GetExtension(fileName)}";
        }
    }
}
