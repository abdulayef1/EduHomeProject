using EduHome.Application.Repositories;
using EduHome.Domain.Entities.Common;
using EduHome.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduHome.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public DbSet<T> Table { get; } 
    public ReadRepository(AppDbContext context)
    {
        _context = context;
        Table = _context.Set<T>();
    }
    
    public async Task<T?> GetByIdAsync(int id) => await Table.FindAsync(id);

    public async Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
        => await (isTracking ? Table : Table.AsNoTracking()).FirstOrDefaultAsync(expression);

    public IQueryable<T> GetAll(bool isTracking=true) => isTracking ? Table : Table.AsNoTracking();

    public IQueryable<T> GetAllByExpression(Expression<Func<T, bool>> expression, bool isTracking = true) 
        => (isTracking ? Table : Table.AsNoTracking()).Where(expression);

}
