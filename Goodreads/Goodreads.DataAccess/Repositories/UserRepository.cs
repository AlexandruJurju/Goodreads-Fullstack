using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Domain.Entities;

namespace Goodreads.DataAccess.Repositories;

public class UserRepository(
    AppDbContext appDbContext
) : IUserRepository
{
    public User? GetUserByEmail(string email)
    {
        return appDbContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public User CreateUser(User user)
    {
        appDbContext.Users.Add(user);
        appDbContext.SaveChanges();
        return user;
    }
}