using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.CountryRepository.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.CountryRepository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly IRepository<Country> _country_repository;

        public CountryRepository(BookContext context, IRepository<Country> country_repository) : base(context)
        {
            _country_repository = country_repository;
        }
        public async Task<bool> Create(CreateCountryCommand command)
        {
            CreateCountryCommandValidator validator = new CreateCountryCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            bool isSuccessfull = await _country_repository.Insert(new Country() 
            { 
                Name = command.Name
            });

            return isSuccessfull;
        }

        public async Task<bool> Update(UpdateCountryCommand command, int Id)
        {
            UpdateCountryCommandValidator validator = new UpdateCountryCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }

            bool isSuccessfull = await _country_repository.Update(new Country()
            {
                Name = command.Name,
                Id = Id
            },
            Id);

            return isSuccessfull;
        }
    }
}
