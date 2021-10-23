using BooksAPI.Data;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Repository.BookRepositories;
using BooksAPI.Service.BookService;
using BooksAPI.Service.GenreService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "BooksAPI.Api", Version = "v1" });
});

builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer("Data Source=DESKTOP-B3Q553I;Initial Catalog=BooksDB;Integrated Security=True"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddScoped(typeof(BookService));
builder.Services.AddScoped(typeof(GenreService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksAPI.Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();