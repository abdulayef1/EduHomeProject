using Microsoft.Extensions.Configuration;

namespace EduHome.Persistence;

static internal class Configuration
{
    internal static string ConnectionString { get 
        {
            ConfigurationManager configuration = new();
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json");
            return configuration.GetConnectionString("Default");
        }
    }
}
