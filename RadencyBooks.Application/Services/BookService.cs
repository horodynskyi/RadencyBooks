using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Exceptions;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Queries.BookQueries;

namespace RadencyBooks.Application.Services;

public class BookService:IBookService
{
    private readonly IRepository<Book> _repository;

    public BookService(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task<List<Book>> GetAllBooksAsync(string order)
    {
        return await _repository.ListAsync(new BookGetAllOrderedQuery(order));
    }

    public async Task<Book> AddAsync(Book book)
    {
        return await _repository.AddAsync(book);
    }

    public async Task<List<Book>> GetTenRecommendedBooksAsync(string? genre)
    {
        return await _repository.ListAsync(new BookGetTenRecommendedQuery(genre));
    }

    public async Task<Book> GetBookDetailAsync(int id)
    {
        var book = await _repository.GetByQueryAsync(new BookListReviewGetByIdQuery(id));
        if (book == null)
            throw new NotFoundException(nameof(Book),id);
        return book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null)
            throw new NotFoundException(nameof(book), id);
        await _repository.DeleteAsync(book);
    }
}