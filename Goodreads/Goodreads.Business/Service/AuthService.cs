using Goodreads.Business.Dtos;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Entities;

namespace Goodreads.Business.Service;

public class AuthService(
    IUserService userService,
    IJwtGenerator jwtGenerator
) : IAuthService
{
    public AuthenticationResult LoginUser(LoginRequest loginRequest)
    {
        // todo: check for exceptions
        var user = userService.GetUserByEmail(loginRequest.Email);
        if (user is null) throw new Exception("User with email not found");

        if (user.Password != loginRequest.Password) throw new Exception("Passwords don't match");

        var token = jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user.Id,
            user.Email,
            token
        );
    }

    public User RegisterUser(RegisterRequest registerRequest)
    {
        if (userService.GetUserByEmail(registerRequest.Email) is not null) throw new Exception("User already exists");

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