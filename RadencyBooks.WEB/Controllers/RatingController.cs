using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Services;

namespace RadencyBooks.WEB.Controllers;

[ApiController]
[Route("api")]
public class RatingController:ControllerBase
{
    private readonly IRatingService _reviewService;
    private readonly IMapper _mapper;

    public RatingController(
        IRatingService reviewService, 
        IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpPost("books/{id}/rating")]
    public async Task<IActionResult> SaveRating(RatingDto reviewDto,int id)
    {
        var review = _mapper.Map<Rating>(reviewDto);
        review.BookId = id;
        var res = await _reviewService.SaveRatingAsync(review);
        return Ok(new {res.Id});
    }
}