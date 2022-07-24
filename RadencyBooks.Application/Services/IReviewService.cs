using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Services;

public interface IReviewService:IService
{
    Task<Review> SaveReviewAsync(Review review);
}