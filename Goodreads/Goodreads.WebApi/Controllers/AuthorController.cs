using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Goodreads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("{id}")]
    public ActionResult<Author> GetAuthor(Guid id)
    {
        try
        {
            var author = _authorService.GetAuthor(id);
            return Ok(author);
        }
        catch (AuthorNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<Author> CreateAuthor([FromBody] Author author)
    {
        _authorService.AddAuthor(author);
        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateAuthor(Guid id, [FromBody] Author author)
    {
        if (id != author.Id)
        {
            return BadRequest();
        }

        try
        {
            _authorService.UpdateAuthor(author);
        }
        catch (AuthorNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAuthor(Guid id)
    {
        try
        {
            _authorService.DeleteAuthor(id);
        }
        catch (AuthorNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}