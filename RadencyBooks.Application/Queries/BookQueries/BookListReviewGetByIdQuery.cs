using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Queries.BookQueries;

public class BookListReviewGetByIdQuery:Query<Book>,ISingleResultQuery
{
    private readonly int _id;

    public BookListReviewGetByIdQuery(int id)
    {
        _id = id;
    }

    protected override IQueryable<Book> GetQuery(DbSet<Book> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .Where(x => x.Id == _id);
    }
}