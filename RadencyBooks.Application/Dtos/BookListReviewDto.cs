using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class BookListReviewDto:IMap
{
    public record BookReview(int Id,string Message, string Reviewer);
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public decimal Rating { get; set; }
    public List<BookReview> Reviews { get; set; } = new();
    

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, BookListReviewDto>()
            .ForMember(dest => dest.Reviews, map =>
                map.MapFrom(s => s.Reviews.Select(x => new BookReview(x.Id,x.Message,x.Reviewer))))
            .ForMember(dest => dest.Rating, map =>
                map.MapFrom(s => s.Reviews.Count==0?0:s.Ratings.Sum(x => x.Score) / s.Ratings.Count));
        profile.CreateMap<BookDto, Book>();
    }
}