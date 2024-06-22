using Goodreads.Domain.Entities;

namespace Goodreads.Business.Persistence;

public interface IBookRepository
{
    Book? GetBookById(int bookId);
}