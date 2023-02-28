API
=============================

API for e-commerce web application for C# project

# API

## all books

http://localhost:5041/api/Books

# links

- <http://localhost:5041/swagger/index.html>

# database

## PostgreSQL

1. change nuget package

```
dotnet remove package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

2. edit appsettings.json

```json
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=32768;Database=kids_bookstore;Username=postgres;Password=postgrespw"
  },
```

3. edit Program.cs

```csharp
builder.Services.AddDbContext<BookStoreContext>(options => 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    options.UseNpgsql(connectionString);
});
```

## in-memory database

1. nuget package

```
dotnet add packageMicrosoft.EntityFrameworkCore.InMemory
```

2. Program.cs

```csharp
builder.Services.AddDbContext<BookStoreContext>(options => 
{
    options.UseInMemoryDatabase("BookStore");
});
```

3. Models/BookStoreContext.cs

```csharp
		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<Category>()
			.HasMany(c => c.books)
			.WithOne(a => a.Category)
			.HasForeignKey(a => a.CategoryId);

			modelBuilder.seed();
		}
```