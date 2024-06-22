namespace Goodreads.Business.Dtos;

public record LoginRequest(
    string Email,
    string Password
);