using EduHome.Domain.Entities.Common;

namespace EduHome.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
{
    public Task<bool> AddAsync(T entity);
    public Task AddRangeAsync(IEnumerable<T> entities);
    public bool Remove(T entity);
    public Task<bool> RemoveByIdAsync(int id);
    public void RemoveRange(IEnumerable<T> entities);
    public bool Update(T entity);
}
