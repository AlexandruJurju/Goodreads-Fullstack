namespace Goodreads.Domain.Exceptions;

public class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException(Guid authorId) : base($"Author not found")
    {
    }
}