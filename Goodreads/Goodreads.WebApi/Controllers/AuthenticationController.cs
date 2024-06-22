using Goodreads.Business.Dtos;
using Goodreads.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Goodreads.Business.Dtos.LoginRequest;
using RegisterRequest = Goodreads.Business.Dtos.RegisterRequest;

namespace Goodreads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController(
    IAuthService authService
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
        var user = authService.RegisterUser(registerRequest);
        return Ok(user);
    }
}