using EduHome.Infrastructure;
using EduHome.Infrastructure.Services.Storage.Azure;
using EduHome.Persistence;

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

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
