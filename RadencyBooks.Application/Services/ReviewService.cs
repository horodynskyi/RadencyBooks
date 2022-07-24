using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Exceptions;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Queries;

namespace RadencyBooks.Application.Services;

public class ReviewService:IReviewService
{
    private readonly IRepository<Review> _repository;
    private readonly IRepository<Book> _bookRepository;

    public ReviewService(
        IRepository<Review> repository, 
        IRepository<Book> bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }

    public async Task<Review> SaveReviewAsync(Review review)
    {
        var book = await _bookRepository.GetByIdAsync(review.BookId);
        if (book == null)
            throw new NotFoundException(nameof(book), review.Id);
        return await _repository.AddAsync(review);
    }
}