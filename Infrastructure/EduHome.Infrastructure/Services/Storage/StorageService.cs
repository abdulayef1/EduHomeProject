using EduHome.Application.Abstraction.Storage;
using EduHome.Application.Helper.StorageResults;
using Microsoft.AspNetCore.Http;

namespace EduHome.Infrastructure.Services.Storage;

public class StorageService : IStorageService
{
    private readonly IStorage _storage;
    public StorageService(IStorage storage)
    {
        _storage = storage;
    }

    public bool Delete(string filePathOrUri, string fileName)
        => _storage.Delete(filePathOrUri, fileName);

    public bool ExistsFile(string filePathOrUri, string fileName)
        => _storage.ExistsFile(filePathOrUri, fileName);
    public Task<FileUploadResult> UploadAsync(IFormFile file, params string[] pathOrContainerName)
        =>_storage.UploadAsync(file, pathOrContainerName);
 
}
