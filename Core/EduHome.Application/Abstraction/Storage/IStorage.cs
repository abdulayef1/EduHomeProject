using EduHome.Application.Helper.StorageResults;
using Microsoft.AspNetCore.Http;

namespace EduHome.Application.Abstraction.Storage;

public interface IStorage
{
    Task<FileUploadResult> UploadAsync(IFormFile file,params string[] pathOrContainerName);
    bool Delete(string filePathOrUri, string fileName);
    bool ExistsFile(string filePathOrUri, string fileName);
} 
