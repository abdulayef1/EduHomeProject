using Microsoft.Extensions.Configuration;

namespace EduHome.Persistence;

static internal class AppSettingConfiguration
{
    internal static string ConnectionString { get 
        {
            Microsoft.Extensions.Configuration.ConfigurationManager configuration = new();
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json");
            return configuration.GetConnectionString("Default");
        }
    }
}
