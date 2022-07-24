namespace RadencyBooks.Application.Models;

public class Review:IAggregateRoot
{
    public int Id { get; set; }
    public string Message { get; set; } = String.Empty;
    public int BookId { get; set; }
    public string Reviewer { get; set; } = String.Empty;
    public Book? Book { get; set; } 
} 