using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Services;

public class RatingService:IRatingService
{
    private IRepository<Rating> _repository;

    public RatingService(IRepository<Rating> repository)
    {
        _repository = repository;
    }

    public async Task<Rating> SaveRatingAsync(Rating review)
    {
        return await _repository.AddAsync(review);
    }
}