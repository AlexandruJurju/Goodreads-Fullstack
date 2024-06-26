using Goodreads.Domain.Entities;

namespace Goodreads.Business.Abstractions.Repositories;

public interface IAuthorRepository
{
    List<Author> GetAllAuthors();
    Author? GetAuthor(Guid authorId);
    void DeleteAuthor(Author author);
    void UpdateAuthor(Author author);
    void AddAuthor(Author author);
}