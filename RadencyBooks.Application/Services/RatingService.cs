using RadencyBooks.Application.Exceptions;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Services;

public class RatingService:IRatingService
{
    private readonly IRepository<Rating> _repository;
    private readonly IRepository<Book> _bookrepository;

    public RatingService(
        IRepository<Rating> repository, 
        IRepository<Book> bookrepository)
    {
        _repository = repository;
        _bookrepository = bookrepository;
    }

    public async Task<Rating> SaveRatingAsync(Rating rating)
    {
        var book = await _bookrepository.GetByIdAsync(rating.BookId);
        if (book == null)
            throw new NotFoundException(nameof(book), rating.Id);
        return await _repository.AddAsync(rating);
    }
}