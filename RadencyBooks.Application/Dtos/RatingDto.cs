using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class RatingDto:IMap
{
    public string Score { get; set; } = String.Empty;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RatingDto, Rating>();
    }
}