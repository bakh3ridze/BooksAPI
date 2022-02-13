using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.CountryRepository;
using BooksAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using BooksAPI.Repository.BookRepository;

namespace BooksAPI.Repository.AuthorRepository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly IRepository<Author> _author_repository;
        private readonly ICountryRepository _country_repository;
        private readonly IBookRepository _book_repository;

        public AuthorRepository(BookContext context, IRepository<Author> author_repository, ICountryRepository country_repository, IBookRepository book_repository) : base(context)
        {
            _author_repository = author_repository;
            _country_repository = country_repository;
            _book_repository = book_repository;
        }
        public async Task<bool> Create(CreateAuthorCommand command)
        {
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            bool isSuccessfull = await _author_repository.Insert(new Author()
            { 
                Name = command.Name, 
                CountryId = command.CountryId
            });

            return isSuccessfull;
        }

        public async Task<IEnumerable<DetailedAuthor>> GetAllDetailed()
        {
            return await Task.Run(() => _entities.Select(x => new DetailedAuthor()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            }));
        }

        public async Task<DetailedAuthor> GetDetailedById(int Id)
        {
            return await Task.Run(() => _entities.Where(x => x.Id == Id).Select(x => new DetailedAuthor()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            }).SingleOrDefault());
        }

        public async Task<bool> Update(UpdateAuthorCommand command, int Id)
        {
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            bool isSuccessfull = await _author_repository.Update(new Author()
            {
                Name = command.Name,
                CountryId = command.CountryId,
                Id = Id
            }, 
            Id);

            return isSuccessfull;
        }
    }
}
