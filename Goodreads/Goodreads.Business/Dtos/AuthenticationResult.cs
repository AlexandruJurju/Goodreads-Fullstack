namespace Goodreads.Business.Dtos;

public record AuthenticationResult(
    Guid Id,
    string Email,
    string Token
);