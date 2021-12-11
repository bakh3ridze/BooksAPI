using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthorRepository
{
    public class AuthorRepository : Repository<Genre>, IAuthorRepository
    {
        private readonly IRepository<Author> _author_repository;

        public AuthorRepository(BookContext context, IRepository<Author> author_repository) : base(context)
        {
            _author_repository = author_repository;
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
