using Blazor.Data;
using BooksAPI.SDK_.AuthHttpClient;
using BooksAPI.SDK_.GenreHttpClient;
using BooksAPI.SDK2.AuthorHttpClient;
using BooksAPI.SDK2.BookHttpClient;
using BooksAPI.SDK2.CountryHttpClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Radzen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient("BookHttpClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7064/api");
});

builder.Services.AddScoped<IAuthorHttpClient, AuthorHttpClient>();
builder.Services.AddScoped<ICountryHttpClient, CountryHttpClient>();
builder.Services.AddScoped<IBookHttpClient, BookHttpClient>();
builder.Services.AddScoped<IGenreHttpClient, GenreHttpClient>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
