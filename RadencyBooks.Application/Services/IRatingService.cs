using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Services;

public interface IRatingService:IService
{
    Task<Rating> SaveRatingAsync(Rating review);
}