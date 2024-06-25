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
    [HttpGet("{bookId}")]
    [ProducesResponseType(200, Type = typeof(Book))]
    public IActionResult GetBookById([FromRoute] int bookId)
    {
        var book = bookService.GetBookById(bookId);
        return Ok(book);
    }
}