using BooksAPI;
using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository;
using BooksAPI.Repository.AuthRepository;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.CountryRepository;
using BooksAPI.Repository.GenreRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksAPI.Api v1"));
}

app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();

app.UseAuthorization();

app.MapControllers();

app.Run();