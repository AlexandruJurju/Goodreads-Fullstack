using Goodreads.Domain.Entities;

namespace Goodreads.Business.Abstractions.Repositories;

public interface IBookRepository
{
    Book? GetBookById(int bookId);
}