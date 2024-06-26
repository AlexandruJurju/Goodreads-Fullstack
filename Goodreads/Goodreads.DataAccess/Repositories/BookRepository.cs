using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Domain.Entities;

namespace Goodreads.DataAccess.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepository
{

    public Book? GetBookById(Guid bookId)
    {
        return appDbContext.Books.Find(bookId);
    }
    
    public IEnumerable<Book> GetAll()
    {
        return appDbContext.Books.ToList();
    }

    public void CreateBook(Book book)
    {
        appDbContext.Books.Add(book);
        appDbContext.SaveChanges();
    }

    public void DeleteBook(Book book)
    {
        appDbContext.Books.Remove(book);
        appDbContext.SaveChanges();
    }

    public void Update(Book book)
    {
        appDbContext.Books.Update(book);
        appDbContext.SaveChanges();
    }
}