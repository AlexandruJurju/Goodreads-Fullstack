﻿using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IBookService
{
    Book GetBookById(Guid bookId);
    IEnumerable<Book> GetAll();
    void CreateBook(Book book);
    void DeleteBook(Guid bookId);
    void UpdateBook(Book book);
}