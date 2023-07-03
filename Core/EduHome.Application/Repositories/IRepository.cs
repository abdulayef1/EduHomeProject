using EduHome.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Application.Repositories;

public interface IRepository<T> where T:BaseEntity
{
    DbSet<T> Table { get;}
}
