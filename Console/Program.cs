// See https://aka.ms/new-console-template for more information
using BooksAPI.Data;
using BooksAPI.Data.Entities;

Console.WriteLine("Hello, World!");

BookContext context = new BookContext();
List<BookGenre> bookGenres = new List<BookGenre>() { new BookGenre() { BookId = 10 }, new BookGenre() { BookId = 11 }, new BookGenre() { BookId = 13 } };
await context.Genres.AddAsync(new Genre() { Name = "axalia", Books = bookGenres });
await context.SaveChangesAsync();
Console.WriteLine("morcha");