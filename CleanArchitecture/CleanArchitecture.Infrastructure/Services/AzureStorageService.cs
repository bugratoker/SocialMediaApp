using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    //azurite --silent --location c:\azurite --debug c:\azurite\debug.log
    public class AzureStorageService : IAzureStorageService
    {
        private AzurePortalStorageSettings azureStorageSettings;
        public AzureStorageService(IOptions<AzurePortalStorageSettings> options)
        {
            azureStorageSettings = options.Value;
            
        }

        public async Task<string> UploadUserImageToBlob(byte[] image,string contentType)
        {
            var blobServiceClient = new BlobServiceClient(azureStorageSettings.ConnectionString);
            var blobContainer = blobServiceClient.GetBlobContainerClient(azureStorageSettings.ContainerName);

            var imageName = Guid.NewGuid().ToString();
            var blobClient = blobContainer.GetBlobClient(imageName);
            await blobClient.UploadAsync(new BinaryData(image),new BlobUploadOptions { 
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType=contentType
                }
            });
            return blobClient.Uri.ToString();

        }


    }
}
