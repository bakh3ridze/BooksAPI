using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.BookRepository.Commands;
using BooksAPI.Repository.GenreRepositories;
using BooksAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IRepository<Author> _authorRepository;
        public BookRepository(BookContext context, IRepository<Book> bookRepository, IGenreRepository genreRepository, IRepository<Author> authorRepository) : base(context)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
        }

        public async Task<bool> Create(CreateBookCommand command)
        {
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            List<BookGenre> genres = new List<BookGenre>();
            foreach (var item in command.GenreIds)
            {
                await Task.Run(() => genres.Add(new BookGenre() { GenreId = item }));
            }

            bool ifSuccesful = await _bookRepository.Insert(
                new Book
                {
                    IsDeleted = command.IsDeleted,
                    Price = command.Price,
                    PublishDate = DateTime.Now.Date,
                    Title = command.Title,
                    AuthorId = command.AuthorId,
                    Genres = genres
                }
                );
            return ifSuccesful;
        }

        public async Task<bool> Update(UpdateBookCommand command, int Id)
        {
            UpdateBookCommanddValidator validator = new UpdateBookCommanddValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            List<BookGenre> genres = new List<BookGenre>();
            foreach (var item in command.GenreIds)
            {
                await Task.Run(() => genres.Add(new BookGenre() { GenreId = item }));
            }

            bool ifSuccesful = await _bookRepository.Update(
                                new Book
                                {
                                    IsDeleted = command.IsDeleted,
                                    Price = command.Price,
                                    PublishDate = DateTime.Now.Date,
                                    Title = command.Title,
                                    AuthorId = command.AuthorId,
                                    Genres = genres,
                                    Id = Id
                                },
                                Id
                );
            return ifSuccesful;
        }
        public async Task<DetailedBook> GetDetailedBook(int Id)
        {
            Book book = await _bookRepository.GetById(Id);

            Author author = await _authorRepository.GetById(book.AuthorId);

            List<Genre> genres = (List<Genre>)await GetGenresByBookId(Id);

            DetailedBook details = new DetailedBook()
            {
                Price = book.Price,
                IsDeleted = book.IsDeleted,
                Title = book.Title,
                PublishDate = book.PublishDate,
                Author = author,
                Genres = genres,
                Id = book.Id
            };
            return details;
        }
        public async Task<IEnumerable<Genre>> GetGenresByBookId(int Id)
        {
            return await _context.Books
                .Where(x => x.Id == Id)
                .SelectMany(x => x.Genres.Select(x => x.Genre))
                .ToListAsync();
        }

        public async Task AddGenresByBookId(int Id, IEnumerable<int>? Ids)
        {
            await Task.Run(() => Ids.ToList().ForEach(async x => await _context.BookGenres.AddAsync(new BookGenre() { BookId = Id, GenreId = x })));
            await _context.SaveChangesAsync();
        }
    }
}