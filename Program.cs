using Microsoft.EntityFrameworkCore;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core InMemory and GraphQL services
builder.Services.AddDbContext<BookContext>(options => options.UseInMemoryDatabase("BookDb"));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookContext>();
    context.Database.EnsureCreated();
    
    // Only seed if no books exist
    if (!context.Books.Any())
    {
        context.Books.AddRange(
            new Book { Title = "C# in Depth", Author = "Jon Skeet", Price = 45.99M },
            new Book { Title = "Pro ASP.NET Core 3", Author = "Adam Freeman", Price = 50.00M },
            new Book { Title = "Entity Framework Core in Action", Author = "Jon P Smith", Price = 39.99M }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
// Only use HTTPS redirection in production
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Map GraphQL endpoint
app.MapGraphQL();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
