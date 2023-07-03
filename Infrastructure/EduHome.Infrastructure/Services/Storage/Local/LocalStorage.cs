using EduHome.Application.Abstraction.Storage.Local;
using EduHome.Application.Helper.StorageResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace EduHome.Infrastructure.Services.Storage.Local;

public class LocalStorage : Storage, ILocalStorage
{
    private readonly IHostingEnvironment _env;

    public LocalStorage(IHostingEnvironment env)
    {
        _env = env;
    }

    public async Task<FileUploadResult> UploadAsync(IFormFile file, params string[] paths)
    {
        try
        {
            if (file.Length > 0)
            {
                string fullPath = Path.Combine(_env.ContentRootPath, "wwwroot");
                foreach (var path in paths)
                {
                    fullPath = Path.Combine(fullPath, path);
                }


                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                string fileName = RenameFile(fullPath, file.FileName, ExistsFile);
                using (var fileStream = new FileStream(Path.Combine(fullPath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return new FileUploadResult(fullPath, fileName);
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed:" + ex.Message);
        }

    }
    public bool Delete(string filePath,string fileName)
    {
        if (ExistsFile(filePath,fileName))
        {
            File.Delete(Path.Combine(filePath, fileName));
            return true;
        }
        return false;
    }
    public bool ExistsFile(string filePath,string fileName)
        => File.Exists(Path.Combine(filePath,fileName));
}
