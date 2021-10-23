using BooksAPI.Data;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Repository.BookRepositories;
using BooksAPI.Sdk;
using BooksAPI.Sdk.Book;
using BooksAPI.Service.GenreService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//var serviceProvider = new ServiceCollection()
//    .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
//    .AddSingleton(typeof(IBookRepository), typeof(BookRepository))
//    .AddSingleton(typeof(BookService))
//    .AddSingleton(typeof(GenreService));
//serviceProvider.AddDbContext<BookContext>(options => options.UseSqlServer("Data Source=DESKTOP-B3Q553I;Initial Catalog=BooksDB;Integrated Security=True"));
//var buildserviceprovider = serviceProvider.BuildServiceProvider();
//var BookService = buildserviceprovider.GetService<IRepository<Book>>();
//Book book = await BookService.GetById(5);
//Console.WriteLine(book.Title + " " + book.Price);

var services = new ServiceCollection()
    .AddSdkServices(o =>    
        o.URL = "https://localhost:7064/"
    );

var buildserviceprovider = services.BuildServiceProvider();
var bookService = buildserviceprovider.GetService<HttpBookService>();
var Books = await bookService.List();


foreach (var item in Books)
{
    Console.WriteLine(item.Title + item.Price + item.GenreId);
}
Console.ReadLine();