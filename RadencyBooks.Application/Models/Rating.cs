namespace RadencyBooks.Application.Models;

public class Rating:IAggregateRoot
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public decimal Score { get; set; }
    public Book? Book { get; set; }
}