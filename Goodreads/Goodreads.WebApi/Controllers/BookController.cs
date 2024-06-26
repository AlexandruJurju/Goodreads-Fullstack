using Goodreads.Business.Dtos.Book;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Goodreads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public BookController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    [HttpGet("{bookId:guid}")]
    [ProducesResponseType(200, Type = typeof(BookDto))]
    public IActionResult GetBookById([FromRoute] Guid bookId)
    {
        try
        {
            var result = _bookService.GetBookById(bookId);
            return Ok(result);
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
    public IActionResult GetAll()
    {
        var books = _bookService.GetAll();
        return Ok(books);
    }

    [HttpDelete("{bookId:guid}")]
    public IActionResult Delete([FromRoute] Guid bookId)
    {
        try
        {
            _bookService.DeleteBook(bookId);
            return NoContent();
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        _bookService.CreateBook(book);
        return CreatedAtAction(nameof(GetBookById), new { bookId = book.Id }, book);
    }
}