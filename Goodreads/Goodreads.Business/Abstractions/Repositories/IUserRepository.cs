using Goodreads.Domain.Entities;

namespace Goodreads.Business.Abstractions.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User CreateUser(User user);
}