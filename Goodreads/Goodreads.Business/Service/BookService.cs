using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;

namespace Goodreads.Business.Service;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Book GetBookById(Guid bookId)
    {
        var book = _bookRepository.GetBookById(bookId);
        if (book is null) throw new BookNotFoundException(bookId);

        return book;
    }

    public IEnumerable<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }

    public void CreateBook(Book book)
    {
        _bookRepository.CreateBook(book);
    }

    public void DeleteBook(Guid bookId)
    {
        var book = _bookRepository.GetBookById(bookId);
        if (book is null) throw new BookNotFoundException(bookId);
        
        _bookRepository.DeleteBook(book);
    }

    public void UpdateBook(Book book)
    {
        _bookRepository.Update(book);
    }
}