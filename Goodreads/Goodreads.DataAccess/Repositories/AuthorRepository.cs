using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Domain.Entities;

namespace Goodreads.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _appDbContext;

    public AuthorRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Author> GetAllAuthors()
    {
        return _appDbContext.Authors.ToList();
    }

    public Author? GetAuthor(Guid authorId)
    {
        return _appDbContext.Authors.Find(authorId);
    }

    public void DeleteAuthor(Author author)
    {
        _appDbContext.Authors.Remove(author);
        _appDbContext.SaveChanges();
    }

    public void UpdateAuthor(Author author)
    {
        _appDbContext.Authors.Update(author);
        _appDbContext.SaveChanges();
    }

    public void AddAuthor(Author author)
    {
        _appDbContext.Authors.Add(author);
        _appDbContext.SaveChanges();
    }
}