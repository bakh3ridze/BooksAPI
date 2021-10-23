using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Service.BookService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.BookService
{
    public class BookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task CreateBook(ModifyBookCommand command)
        {
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }
            await _repository.Insert(
                new Book
                {
                    GenreId = command.GenreId,
                    IsDeleted = command.IsDeleted,
                    Price = command.Price,
                    PublishDate = DateTime.Now.Date,
                    Title = command.Title
                }
                );
        }

        public async Task UpdateBook(ModifyBookCommand command, int Id)
        {
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = await validator.ValidateAsync(command);
            Book ifExists = await _repository.GetById(Id);
            if (!result.IsValid && ifExists == null)
            {
                throw new Exception("FluentValidationExeption");
            }
            await _repository.Update(
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
        }
    }
}
