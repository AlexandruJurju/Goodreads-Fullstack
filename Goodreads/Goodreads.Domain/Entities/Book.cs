﻿namespace Goodreads.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int PageCount { get; set; }
}