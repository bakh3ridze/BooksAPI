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

            bool ifSuccesful = await _bookRepository.Insert(
                new Book
                {
                    IsDeleted = command.IsDeleted,
                    Price = command.Price,
                    PublishDate = DateTime.Now.Date,
                    Title = command.Title,
                    AuthorId = command.AuthorId,
                    Genres = new List<BookGenre>(command.GenreIds.Select(x => new BookGenre() { GenreId = x }))
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

            await Task.Run(() => _context.BookGenres.RemoveRange(_context.BookGenres.Where(x => x.BookId == Id)));

            bool ifSuccesful = await _bookRepository.Update(
                                new Book
                                {
                                    IsDeleted = command.IsDeleted,
                                    Price = command.Price,
                                    PublishDate = command.PublishDate,
                                    Title = command.Title,
                                    AuthorId = command.AuthorId,
                                    Id = Id
                                },
                                Id
                );

            Book toAddGenres = await _context.Books.SingleOrDefaultAsync(x => x.Id == Id);
            toAddGenres.Genres = new List<BookGenre>(command.GenreIds.Select(x => new BookGenre() { GenreId = x }));
            await _context.SaveChangesAsync();
            return ifSuccesful;
        }

        public async Task<IEnumerable<DetailedBook>> GetAllDetailed()
        {
            return await Task.Run(() => _entities.Select(x => new DetailedBook()
            {
                Id = x.Id,
                Author = x.Author,
                AuthorId = x.AuthorId,
                IsDeleted = x.IsDeleted,
                Price = x.Price,
                Title = x.Title,
                PublishDate = x.PublishDate,
                Genres = x.Genres
                    .Select(m => m.Genre)
            }));
        }

        public async Task<IEnumerable<DetailedBook>> GetDetailedsByAuthorId(int Id)
        {
            return await Task.Run(() => _entities.Where(x => x.AuthorId == Id).Select(x => new DetailedBook()
            {
                Id = x.Id,
                Author = x.Author,
                AuthorId = x.AuthorId,
                IsDeleted = x.IsDeleted,
                Price = x.Price,
                Title = x.Title,
                PublishDate = x.PublishDate,
                Genres = x.Genres
                    .Select(m => m.Genre)
            }));
        }

        public async Task<DetailedBook> GetDetailedById(int Id)
        {
            return await Task.Run(() => _entities.Where(x => x.Id == Id).Select(x => new DetailedBook()
            {
                Id = x.Id,
                Author = x.Author,
                AuthorId = x.AuthorId,
                IsDeleted = x.IsDeleted,
                Price = x.Price,
                Title = x.Title,
                PublishDate = x.PublishDate,
                Genres = x.Genres
                    .Select(m => m.Genre)
            }).SingleOrDefault());
        }

        public async Task<IEnumerable<DetailedBook>> GetAllNotDeletedDetaileds()
        {
            return await Task.Run(() => _entities.Where(x => x.IsDeleted == false).Select(x => new DetailedBook()
            {
                Id = x.Id,
                Author = x.Author,
                AuthorId = x.AuthorId,
                IsDeleted = x.IsDeleted,
                Price = x.Price,
                Title = x.Title,
                PublishDate = x.PublishDate,
                Genres = x.Genres
                .Select(m => m.Genre)
            }));
        }
    }
}