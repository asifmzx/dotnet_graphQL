using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }
}
