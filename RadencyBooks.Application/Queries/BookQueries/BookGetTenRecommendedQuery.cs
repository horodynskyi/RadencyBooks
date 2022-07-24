using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Queries.BookQueries;

public class BookGetTenRecommendedQuery:Query<Book>,IListResultQuery
{
    private readonly string _genre;

    public BookGetTenRecommendedQuery(string genre)
    {
        _genre = genre;
    }

    protected override IQueryable<Book> GetQuery(DbSet<Book> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .Where(x => x.Reviews.Count>10)
            .Where(x => string.IsNullOrEmpty(_genre)==true || x.Genre.ToLower()==_genre.ToLower())
            .OrderByDescending(x => x.Ratings!.Sum(r => r.Score))
            .Take(10);

    }
}