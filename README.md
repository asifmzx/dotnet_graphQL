# GraphQL Demo - .NET 8 Project

A simple GraphQL API built with HotChocolate and Entity Framework Core.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
- Git

## Getting Started

1. **Clone the repository:**git clone <repository-url>
cd GraphQLDemo
2. **Restore packages:**dotnet restore
3. **Build the project:**dotnet build
4. **Run the application:**dotnet run
5. **Access the GraphQL Playground:**
   - Open your browser and navigate to: `https://localhost:7250/graphql`
   - Or use the HTTP endpoint: `http://localhost:5114/graphql`

## Project Structure

- `Book.cs` - Book entity model
- `BookInput.cs` - GraphQL input type for mutations
- `BookContext.cs` - Entity Framework DbContext
- `Query.cs` - GraphQL queries
- `Mutation.cs` - GraphQL mutations
- `Program.cs` - Application startup and configuration

## Dependencies

This project uses the following NuGet packages:
- **HotChocolate.AspNetCore** (15.1.7) - GraphQL server
- **HotChocolate.Data** (15.1.7) - Data integration
- **HotChocolate.Data.EntityFramework** (15.1.7) - EF Core integration
- **HotChocolate.Types** (15.1.7) - GraphQL types
- **Microsoft.EntityFrameworkCore.InMemory** (9.0.7) - In-memory database

## Sample GraphQL Operations

### Query all books:query {
  books {
    id
    title
    author
    price
  }
}
### Add a new book:mutation {
  addBook(book: { 
    title: "GraphQL for .NET Developers", 
    author: "John Doe", 
    price: 29.99 
  }) {
    id
    title
    author
    price
  }
}
## Development Commands

| Command | Description |
|---------|-------------|
| `dotnet restore` | Download and install packages |
| `dotnet build` | Compile the project |
| `dotnet run` | Run the application |
| `dotnet clean` | Clean build artifacts |
| `dotnet watch run` | Run with hot reload |

## Database

This project uses Entity Framework Core with an in-memory database. The database is automatically seeded with sample data when the application starts.

Special thanks to [HotChocolate](https://chillicream.com/docs/hotchocolate) for providing a powerful GraphQL framework for .NET. & @Paulo Torres https://medium.com/@paulotorres/implementing-graphql-in-net-core-4fb2b0ca6e02 for providing the tutorial and inspiration for this project.