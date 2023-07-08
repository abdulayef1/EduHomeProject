using EduHome.Domain.Entities;
using EduHome.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Persistence.Contexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}
    public DbSet<Course> Courses { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
