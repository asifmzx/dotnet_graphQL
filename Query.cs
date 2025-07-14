using HotChocolate;
using HotChocolate.Data;

public class Query
{
    public IQueryable<Book> GetBooks(BookContext context) =>
        context.Books;
}