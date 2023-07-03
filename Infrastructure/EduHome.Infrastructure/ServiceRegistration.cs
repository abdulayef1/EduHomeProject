using EduHome.Application.Abstraction.Storage;
using EduHome.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EduHome.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService,StorageService>();
    }

    public static void AddStorage<T>(this IServiceCollection services) where T :Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
    }
}
