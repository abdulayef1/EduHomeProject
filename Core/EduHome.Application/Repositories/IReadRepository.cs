using EduHome.Domain.Entities.Common;
using System.Linq.Expressions;

namespace EduHome.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression,bool isTracking=true);
    IQueryable<T> GetAll(bool isTracking=true);
    IQueryable<T> GetAllByExpression(Expression<Func<T, bool>> expression,bool isTracking=true);
}
