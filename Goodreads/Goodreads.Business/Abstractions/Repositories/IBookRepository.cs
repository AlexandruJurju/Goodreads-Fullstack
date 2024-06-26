using Goodreads.Domain.Entities;

namespace Goodreads.Business.Abstractions.Repositories;

public interface IBookRepository
{
    Book? GetBookById(Guid bookId);
    IEnumerable<Book> GetAll();
    void CreateBook(Book book);
    void DeleteBook(Book book);
    void Update(Book book);
}