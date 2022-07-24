using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Services;

namespace RadencyBooks.WEB.Controllers;
[ApiController]
[Route("api")]
public class ReviewController:ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(
        IReviewService reviewService, 
        IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpPost("books/{id}/review")]
    public async Task<IActionResult> SaveReview(ReviewDto reviewDto,int id)
    {
        var review = _mapper.Map<Review>(reviewDto);
        review.BookId = id;
        var res = await _reviewService.SaveReviewAsync(review);
        return Ok(new {res.Id});
    }
}