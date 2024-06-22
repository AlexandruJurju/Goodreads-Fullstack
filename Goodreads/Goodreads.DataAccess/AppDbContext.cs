using Goodreads.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}