using EduHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
     //todo search the DbContextOptions   
    }

}
