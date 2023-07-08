using EduHome.Application.Repositories;
using EduHome.Domain.Entities;
using EduHome.Persistence.Contexts;

namespace EduHome.Persistence.Repositories;

public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
{
    public CourseReadRepository(AppDbContext context) : base(context)
    {
    }
}
