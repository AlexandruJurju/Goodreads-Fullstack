namespace Goodreads.Business.Dtos.Authentication;

public record LoginRequest(
    string Email,
    string Password
);