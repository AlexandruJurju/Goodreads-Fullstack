namespace Goodreads.Domain.Exceptions;

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException() : base("Passwords don't match")
    {
    }
}