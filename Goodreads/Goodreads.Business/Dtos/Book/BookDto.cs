namespace Goodreads.Business.Dtos.Book;

public record BookDto(
    Guid Id,
    string Title,
    int PageCount
);