namespace Goodreads.Business.Dtos.Book;

public record CreateBookRequest(
    string Title,
    int PageCount
);