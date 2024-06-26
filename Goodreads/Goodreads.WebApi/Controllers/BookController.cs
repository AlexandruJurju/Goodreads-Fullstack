using Goodreads.Business.Dtos.Book;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Goodreads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController(
    IBookService bookService
) : ControllerBase
{
    [HttpGet("{bookId:guid}")]
    [ProducesResponseType(200, Type = typeof(BookDto))]
    public IActionResult GetBookById([FromRoute] Guid bookId)
    {
        var result = bookService.GetBookById(bookId);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
    public IActionResult GetAll()
    {
        var books = bookService.GetAll();
        return Ok(books);
    }

    [HttpDelete("{bookId:guid}")]
    public IActionResult Delete([FromRoute] Guid bookId)
    {
        var result = bookService.GetBookById(bookId);
        return NoContent();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        bookService.CreateBook(book);
        return CreatedAtAction(nameof(GetBookById), new { bookId = book.Id }, book);
    }
}