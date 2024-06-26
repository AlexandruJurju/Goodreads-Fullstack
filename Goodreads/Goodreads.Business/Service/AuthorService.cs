using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;

namespace Goodreads.Business.Service;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public List<Author> GetAllAuthors()
    {
        return _authorRepository.GetAllAuthors();
    }

    public Author GetAuthor(Guid authorId)
    {
        var author = _authorRepository.GetAuthor(authorId);
        if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }

    public void AddAuthor(Author author)
    {
        _authorRepository.AddAuthor(author);
    }

    public void UpdateAuthor(Author author)
    {
        var existingAuthor = _authorRepository.GetAuthor(author.Id);
        if (existingAuthor is null) throw new AuthorNotFoundException(author.Id);

        _authorRepository.UpdateAuthor(author);
    }

    public void DeleteAuthor(Guid authorId)
    {
        var existingAuthor = _authorRepository.GetAuthor(authorId);
        if (existingAuthor is null) throw new AuthorNotFoundException(authorId);

        _authorRepository.DeleteAuthor(existingAuthor);
    }
}