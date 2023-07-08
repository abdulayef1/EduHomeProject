using EduHome.Application;
using EduHome.Domain.Entities;
using EduHome.Persistence.Contexts;
using EduHome.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity;
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

        
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = true;

            options.User.RequireUniqueEmail = true;

            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(45);

        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();






        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
