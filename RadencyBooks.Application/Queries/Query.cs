using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Queries;

public abstract class Query<T> where T : class,IAggregateRoot
{
    public IQueryable<T> Execute(DbSet<T> dbSet)
    {
        return GetQuery(dbSet);
    }

    protected abstract IQueryable<T> GetQuery(DbSet<T> dbSet);
}