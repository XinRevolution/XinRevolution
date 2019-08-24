using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using XinRevolution.Manager.Models;

namespace XinRevolution.Manager.Service
{
    public class AzureBlobService
    {
        private readonly string _connectionString;

        public AzureBlobService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Blob");
        }

        public OperationResult<string> Save(string containerName, IFormFile file)
        {
            var result = new OperationResult<string>();
            var stream = new MemoryStream();

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

                file.CopyTo(stream);

                var blockBlob = blobContainer.GetBlockBlobReference(fileName);
                blockBlob.UploadFromStream(stream);

                stream.Dispose();

                result.Status = true;
                result.Message = $"儲存成功";
                result.Data = blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                stream.Dispose();

                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public OperationResult Remove(string resourceUrl)
        {
            OperationResult result = new OperationResult();

            try
            {
                var blockBlob = new CloudBlockBlob(new Uri(resourceUrl));
                blockBlob.Delete();

                result.Status = true;
                result.Message = $"刪除成功";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }

            return result;
        }

        private string GetFileName(string fileName)
        {
            return $"{Path.GetFileName(fileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{Path.GetExtension(fileName)}";
        }
    }
}
