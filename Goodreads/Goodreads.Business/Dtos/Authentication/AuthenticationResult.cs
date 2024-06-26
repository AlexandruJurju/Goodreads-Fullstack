namespace Goodreads.Business.Dtos.Authentication;

public record AuthenticationResult(
    Guid Id,
    string Email,
    string Token
);