using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class ReviewDto:IMap
{
    public string Message { get; set; } = String.Empty;
    public string Reviewer { get; set; } = String.Empty;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ReviewDto, Review>();
    }
}