using EduHome.Application.Repositories;
using EduHome.Domain.Entities;
using EduHome.Persistence.Contexts;

namespace EduHome.Persistence.Repositories;

public class CourseWriteRepository : WriteRepository<Course>, ICourseWriteRepository
{
    public CourseWriteRepository(AppDbContext context) : base(context)
    {
    }
}
