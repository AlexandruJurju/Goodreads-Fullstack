using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IBookService
{
    Book GetBookById(int bookId);
}