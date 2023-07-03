using EduHome.Application;
using EduHome.Persistence.Contexts;

namespace EduHome.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    //fields
    //private ICourseWriteRepository? _courseWriteRepository;
    //private ICourseReadRepository? _courseReadRepository;


    //Properties
    //public ICourseWriteRepository CourseWriteRepository => _courseWriteRepository =_courseWriteRepository ?? new CourseWriteRepository(_context);
   // public ICourseReadRepository CourseReadRepository => _courseReadRepository = _courseReadRepository ?? new CourseReadRepository(_context);


    //methods
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
       return await _context.SaveChangesAsync();
    }
}
