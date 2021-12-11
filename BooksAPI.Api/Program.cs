using BooksAPI.Data;
using BooksAPI.Repository.AuthorRepository;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.CountryRepositories;
using BooksAPI.Repository.GenreRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "BooksAPI.Api", Version = "v1" });
});

builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-B3Q553I;Initial Catalog=BooksDB;Integrated Security=True"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IGenreRepository), typeof(GenreRepository));
builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
builder.Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));

var app = builder.Build();

app.UseCors("CorsPolicy");

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