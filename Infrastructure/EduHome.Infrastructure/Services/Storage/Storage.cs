namespace EduHome.Infrastructure.Services.Storage;

public class Storage
{
    protected delegate bool ExistsFile(string filePathOrUri,string fileName);
    protected string RenameFile(string filePathOrUri, string fileName, ExistsFile existsFile)
    {
        
        string extension = Path.GetExtension(fileName);
        int i = 0;
        while (existsFile(filePathOrUri, fileName))
        {
            if (i == 0)
                fileName = fileName.Replace(extension, $"({++i}){extension}");
            else
                fileName = fileName.Replace($"({i}){extension}", $"({++i}){extension}");
        }

        return fileName;
    }

}
