namespace Goodreads.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = String.Empty;

    public int PageCount { get; set; }
}