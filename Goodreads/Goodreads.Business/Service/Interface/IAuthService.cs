using Goodreads.Business.Dtos;
using Goodreads.Business.Dtos.Authentication;
using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service.Interface;

public interface IAuthService
{
    AuthenticationResult LoginUser(LoginRequest loginRequest);
    User RegisterUser(RegisterRequest registerRequest);
}