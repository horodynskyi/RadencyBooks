using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Queries;

namespace RadencyBooks.Application.Services;

public class ReviewService:IReviewService
{
    private IRepository<Review> _repository;

    public ReviewService(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<Review> SaveReviewAsync(Review review)
    {
        return await _repository.AddAsync(review);
    }
}