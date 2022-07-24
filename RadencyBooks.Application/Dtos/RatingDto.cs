using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class RatingDto:IMap
{
    public decimal Score { get; set; } 
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RatingDto, Rating>();
    }
}