using Goodreads.Business.Persistence;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public Book? GetBookById(int bookId)
    {
        return bookRepository.GetBookById(bookId);
    }
}