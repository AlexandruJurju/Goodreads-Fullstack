using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;

namespace Goodreads.Business.Service;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public Book GetBookById(int bookId)
    {
        var book = bookRepository.GetBookById(bookId);
        if (book is null) throw new BookNotFoundException(bookId);

        return book;
    }
}