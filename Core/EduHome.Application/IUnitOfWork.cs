namespace EduHome.Application;

public interface IUnitOfWork:IDisposable
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default);

    //public ICourseWriteRepository CourseWriteRepository { get; }
    //public ICourseReadRepository CourseReadRepository { get;  }
}
