using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using BookApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

var app = builder.Build();

// tworzy baze danych przy starcie jesli nie istnieje
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
    db.Database.EnsureCreated();
}

// pobierz wszystkie ksiazki
app.MapGet("/api/books", async (BooksDbContext db) =>
{
    var books = await db.Books.ToListAsync();
    return Results.Ok(books);
});

// pobierz ksiazke po id
app.MapGet("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null)
        return Results.NotFound("Nie znaleziono książki o podanym ID.");

    return Results.Ok(book);
});

// dodaj nowa ksiazke
app.MapPost("/api/books", async (Book book, BooksDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();

    return Results.Created($"/api/books/{book.Id}", book);
});

// zaktualizuj ksiazke
app.MapPut("/api/books/{id}", async (int id, Book input, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null)
        return Results.NotFound("Nie znaleziono książki o podanym ID.");

    book.Title = input.Title;
    book.Author = input.Author;
    book.PublishedYear = input.PublishedYear;
    book.IsRead = input.IsRead;

    await db.SaveChangesAsync();

    return Results.Ok(book);
});

// usun ksiazke
app.MapDelete("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null)
        return Results.NotFound("Nie znaleziono książki o podanym ID.");

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.Ok("Książka usunięta.");
});

app.Run();