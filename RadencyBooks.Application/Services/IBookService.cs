using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Services;

public interface IBookService:IService
{
    Task<List<Book>> GetAllBooksAsync(string order);
    Task<Book> AddAsync(Book book);
    Task<List<Book>> GetTenRecommendedBooksAsync(string? genre);
    Task<Book> GetBookDetailAsync(int id);
    Task DeleteBookAsync(int id);
}