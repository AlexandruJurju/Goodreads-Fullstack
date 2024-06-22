using Goodreads.Business.Abstractions.Repositories;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service;

public class UserService(
    IUserRepository userRepository
) : IUserService
{
    public User? GetUserByEmail(string email)
    {
        return userRepository.GetUserByEmail(email);
    }

    public User CreateUser(User user)
    {
        return userRepository.CreateUser(user);
    }
}