using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EduHome.Application.Abstraction.Storage.Azure;
using EduHome.Application.Helper.StorageResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EduHome.Infrastructure.Services.Storage.Azure;

public class AzureStorage : Storage, IAzureStorage
{
    readonly BlobServiceClient _blobServiceClient;
    BlobContainerClient _blobContainerClient;

    public AzureStorage(IConfiguration configuration)
    {
        _blobServiceClient = new(configuration["Storage:Azure"]);
    }


    public bool Delete(string containerName, string fileName)
    {
        if(!ExistsFile(containerName,fileName)) return false;
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
        blobClient.Delete();
        return true;
    }

    public bool ExistsFile(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
    }

    public async Task<FileUploadResult> UploadAsync(IFormFile file, params string[] pathOrContainerName)
    {
        string containerName = pathOrContainerName[0];
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        string fileNewName =  RenameFile(containerName, file.FileName, ExistsFile);

        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
        await blobClient.UploadAsync(file.OpenReadStream());
        return new FileUploadResult( $"{containerName}/{fileNewName}", fileNewName);
    }
}
