using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IAuthorService
{
    List<Author> GetAllAuthors();
    Author GetAuthor(Guid authorId);
    void AddAuthor(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(Guid authorId);
}