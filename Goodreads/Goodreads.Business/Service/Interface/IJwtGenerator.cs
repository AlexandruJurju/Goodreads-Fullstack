using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}