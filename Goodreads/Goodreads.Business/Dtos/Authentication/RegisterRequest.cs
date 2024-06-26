namespace Goodreads.Business.Dtos.Authentication;

public record RegisterRequest(
    string Email,
    string Username,
    string Password
);