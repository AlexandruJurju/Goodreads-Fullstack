namespace Goodreads.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}