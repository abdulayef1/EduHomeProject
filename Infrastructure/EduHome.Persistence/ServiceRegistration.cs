using EduHome.Application;
using EduHome.Persistence.Contexts;
using EduHome.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EduHome.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {

        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(AppSettingConfiguration.ConnectionString));
        services.AddSingleton<BaseEntitiesInterceptor>();
        services.AddDbContext<AppDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)((serviceProvider, options) =>
        {
            var interceptor = serviceProvider
             .GetService<BaseEntitiesInterceptor>();

            options
             .UseSqlServer(AppSettingConfiguration.ConnectionString)
             .AddInterceptors(interceptor); //Attaching it to the DB context
        }));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
