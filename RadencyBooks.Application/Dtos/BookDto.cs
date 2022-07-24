using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class BookDto:IMap
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public decimal Rating { get; set; }
    public decimal ReviewsNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, BookDto>()
            .ForMember(dest => dest.ReviewsNumber, map =>
                map.MapFrom(s => s.Reviews!.Count))
            .ForMember(dest => dest.Rating, map =>
                map.MapFrom(s => s.Reviews != null && s.Reviews.Count==0?0:s.Ratings.Sum(x => x.Score) / s.Ratings.Count));
        profile.CreateMap<BookDto, Book>();
    }
}