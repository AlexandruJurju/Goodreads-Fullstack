using Goodreads.Business.Dtos;
using Goodreads.Business.Dtos.Authentication;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;
using Goodreads.Domain.Exceptions;

namespace Goodreads.Business.Service;

public class AuthService(
    IUserService userService,
    IJwtGenerator jwtGenerator
) : IAuthService
{
    public AuthenticationResult LoginUser(LoginRequest loginRequest)
    {
        var user = userService.GetUserByEmail(loginRequest.Email);
        if (user is null) throw new UserNotFoundException(loginRequest.Email);

        if (user.Password != loginRequest.Password) throw new PasswordMismatchException();

        var token = jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user.Id,
            user.Email,
            token
        );
    }

    public User RegisterUser(RegisterRequest registerRequest)
    {
        if (userService.GetUserByEmail(registerRequest.Email) is not null) throw new DuplicateEmailException(registerRequest.Email);

        User user = new User()
        {
            CreatedDateTime = DateTime.UtcNow,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            UpdatedDateTime = DateTime.UtcNow,
            Username = registerRequest.Username
        };

        return userService.CreateUser(user);
    }
}