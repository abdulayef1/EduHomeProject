using EduHome.Domain.Entities;
using EduHome.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
     //todo search the DbContextOptions   
    }
    public DbSet<Course> Courses { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
    }

}
