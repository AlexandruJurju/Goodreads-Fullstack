using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Domain.Entities;

namespace Goodreads.DataAccess.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepository
{

    public Book? GetBookById(int bookId)
    {
        return appDbContext.Books.Find(bookId);
    }
}