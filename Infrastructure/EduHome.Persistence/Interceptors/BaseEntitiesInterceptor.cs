using EduHome.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EduHome.Persistence.Interceptors;

public class BaseEntitiesInterceptor:SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {

        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

       var entityEntries= eventData.Context.ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entityEntries)
        {
            if (entry.State == EntityState.Added)
            {
               entry.Entity.OnCreated=DateTime.UtcNow;
            }

        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
