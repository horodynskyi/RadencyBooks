using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Queries;

public class ReviewsGetByBookIdQuery:Query<Review>,IListResultQuery
{
    private readonly int _id;

    public ReviewsGetByBookIdQuery(int id)
    {
        _id = id;
    }

    protected override IQueryable<Review> GetQuery(DbSet<Review> dbSet)
    {
        return dbSet.Where(x => x.BookId == _id);
    }
}