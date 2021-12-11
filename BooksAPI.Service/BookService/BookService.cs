using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Repository.BookRepositories;
using BooksAPI.Service.BookService.Commands;
using BooksAPI.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.BookService
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Genre> _genreRepository;

        public BookService(IRepository<Book> bookrepository, IRepository<Genre> genreRepository)
        {
            _bookRepository = bookrepository;
            _genreRepository = genreRepository;
        }

        public async Task<bool> CreateBook(ModifyBookCommand command)
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
                    GenreId = command.GenreId,
                    IsDeleted = command.IsDeleted,
                    Price = command.Price,
                    PublishDate = DateTime.Now.Date,
                    Title = command.Title
                }
                );
            return ifSuccesful;
        }

        public async Task<bool> UpdateBook(ModifyBookCommand command, int Id)
        {
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }
            bool ifSuccesful = await _bookRepository.Update(
                                new Book
                                {
                                    GenreId = command.GenreId,
                                    IsDeleted = command.IsDeleted,
                                    Price = command.Price,
                                    PublishDate = DateTime.Now.Date,
                                    Title = command.Title
                                },
                                Id
                );
            return ifSuccesful;
        }

        public async Task<BookDetails> Details(int Id)
        {
            IEnumerable<Book> books = await _bookRepository.GetAll();
            Book? book = await Task.Run(() => books.SingleOrDefault(x => x.Id == Id));
            Genre? BookGenre = await _genreRepository.GetById(book.GenreId);
            BookDetails? details = new BookDetails()
            {
                GenreId = book.GenreId,
                GenreName = BookGenre.Name,
                Price = book.Price,
                IsDeleted = book.IsDeleted,
                Title = book.Title,
                PublishDate = book.PublishDate
            };
            return details;
        }
    }
}
