using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Queries.BookQueries;

public class BookGetAllOrderedQuery:Query<Book>,IListResultQuery
{
    
    private readonly Func<Book,string> _order;
    public BookGetAllOrderedQuery(string? order)
    {
        _order = order == "author" ? book => book.Author : book => book.Title;
    }

    protected override IQueryable<Book> GetQuery(DbSet<Book> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .OrderBy(_order)
            .AsQueryable(); 
    }
}
