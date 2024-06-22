using Goodreads.Business.Persistence;
using Goodreads.Domain.Entities;

namespace Goodreads.DataAccess.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepository
{

    public Book? GetBookById(int bookId)
    {
        return appDbContext.Books.Find(bookId);
    }
}