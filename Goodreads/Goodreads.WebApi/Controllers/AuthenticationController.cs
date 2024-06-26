using Goodreads.Business.Dtos;
using Goodreads.Business.Dtos.Authentication;
using Goodreads.Business.Service.Interface;
using Goodreads.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Goodreads.Business.Dtos.Authentication.LoginRequest;
using RegisterRequest = Goodreads.Business.Dtos.Authentication.RegisterRequest;

namespace Goodreads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController(
    IAuthService authService,
    IUserService userService
) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(200, Type = typeof(AuthenticationResult))]
    public IActionResult LoginUser([FromBody] LoginRequest loginRequest)
    {
        var authResult = authService.LoginUser(loginRequest);
        return Ok(authResult);
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterRequest registerRequest)
    {
        if (userService.GetUserByEmail(registerRequest.Email) is not null)
        {
            throw new DuplicateEmailException(registerRequest.Email);
        }
        
        var user = authService.RegisterUser(registerRequest);
        return Ok(user);
    }
}