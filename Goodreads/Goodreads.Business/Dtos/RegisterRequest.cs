namespace Goodreads.Business.Dtos;

public record RegisterRequest(
    string Email,
    string Username,
    string Password
);