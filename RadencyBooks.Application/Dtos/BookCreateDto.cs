using AutoMapper;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Dtos;

public class BookCreateDto:IMap
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Cover { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BookCreateDto, Book>();
    }
}