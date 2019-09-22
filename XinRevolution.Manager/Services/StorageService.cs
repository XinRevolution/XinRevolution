using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XinRevolution.Manager.Models;

namespace XinRevolution.Manager.Services
{
    public class StorageService
    {
        private readonly string _connectionString;

        public StorageService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Blob");
        }

        public OperationResult<string> Save(string containerName, IFormFile file)
        {
            var result = new OperationResult<string>();

            using (var stream = new MemoryStream())
            {
                try
                {
                    if (file == null || file.Length <= 0)
                        throw new Exception($"檔案異常");

                    var fileName = new Guid().ToString();
                    var storageAccount = CloudStorageAccount.Parse(_connectionString);
                    var blobClient = storageAccount.CreateCloudBlobClient();

                    var blobContainer = blobClient.GetContainerReference(containerName.ToLower());
                    blobContainer.CreateIfNotExists();

                    var permision = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob };
                    blobContainer.SetPermissions(permision);

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
            }

            return result;
        }

        public void Delete(string resourceUrl)
        {
            try
            {
                var blockBlob = new CloudBlockBlob(new Uri(resourceUrl));
                blockBlob.Delete();
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(IEnumerable<string> resourceUrls)
        {
            try
            {
                foreach (var url in resourceUrls)
                {
                    var blockBlob = new CloudBlockBlob(new Uri(url));
                    blockBlob.Delete();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
