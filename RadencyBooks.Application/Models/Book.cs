namespace RadencyBooks.Application.Models;

public class Book:IAggregateRoot
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Cover { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public List<Review>? Reviews { get; set; } = new();
    public List<Rating>? Ratings { get; set; }= new();

}