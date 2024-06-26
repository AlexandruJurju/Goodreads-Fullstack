namespace Goodreads.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int PageCount { get; set; }
}