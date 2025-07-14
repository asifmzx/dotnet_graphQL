using HotChocolate;
using HotChocolate.Data;

public class Mutation
{
    public async Task<Book> AddBookAsync(BookInput book, BookContext context)
    {
        var newBook = new Book
        {
            Title = book.Title,
            Author = book.Author,
            Price = book.Price
        };
        context.Books.Add(newBook);
        await context.SaveChangesAsync();
        return newBook;
    }
}