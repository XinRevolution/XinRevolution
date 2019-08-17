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
    public class AzureBlobManagementService
    {
        private readonly string _blobConnectionString;

        public AzureBlobManagementService(IConfiguration Config)
        {
            _blobConnectionString = Config.GetConnectionString("Blob");
        }

        public OperationResult<string> Save(string containerName, IFormFile file, string fileName, string fileMimetype)
        {
            var result = new OperationResult<string>();
            
            try
            {
                var storageAccount = CloudStorageAccount.Parse(_blobConnectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);

                if (container.CreateIfNotExists())
                    container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                using (var memoryStream = new MemoryStream())
                {
                    var blockBlob = container.GetBlockBlobReference(fileName);

                    file.CopyTo(memoryStream);
                    
                    blockBlob.Properties.ContentType = fileMimetype;
                    blockBlob.UploadFromStream(memoryStream);

                    result.Status = true;
                    result.Data = blockBlob.Uri.AbsoluteUri;
                }

            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public string Remove()
        {
            return string.Empty;
        }
    }
}
