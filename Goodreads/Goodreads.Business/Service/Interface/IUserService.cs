using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IUserService
{
    User? GetUserByEmail(string email);
    User CreateUser(User user);
}