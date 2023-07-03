using EduHome.Application.Repositories;
using EduHome.Domain.Entities.Common;
using EduHome.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EduHome.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public DbSet<T> Table { get; }

    public WriteRepository(AppDbContext context)
    {
        _context = context;
        Table = _context.Set<T>();
    }

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
        => await Table.AddRangeAsync(entities);

    public bool Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveByIdAsync(int id)
    {
        var entity = await Table.FindAsync(id);
        return entity != null ? Remove(entity) : false;
    }
    public void RemoveRange(IEnumerable<T> entities)
        => Table.RemoveRange(entities);

    public bool Update(T entity)
    {
        EntityEntry<T> entityEntry = Table.Update(entity);
        return entityEntry.State==EntityState.Modified; 
    }






}
