using EduHome.Domain.Entities;
using EduHome.Infrastructure;
using EduHome.Infrastructure.Services.Storage.Azure;
using EduHome.Persistence;
using EduHome.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Infrstucture layer's services
builder.Services.AddInfrastructureServices();
//You can change the storage of project with one line
//builder.Services.AddStorage<LocalStorage>(); 

//Storaged is added
builder.Services.AddStorage<AzureStorage>();

//
builder.Services.AddPersistanceServices();

builder.Services.AddControllersWithViews();

//builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
//{
//    options.Password.RequiredLength = 8;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireDigit = true;
//    options.Password.RequireNonAlphanumeric = true;

//    options.User.RequireUniqueEmail = true;

//    options.Lockout.AllowedForNewUsers = true;
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(45);

//}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Auth/Login";
    //opt.AccessDeniedPath = "/";

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
