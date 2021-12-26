using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.CountryRepository.Commands;

namespace BooksAPI.Repository.CountryRepository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<bool> Create(CreateCountryCommand command);
        Task<bool> Update(UpdateCountryCommand command, int Id);
    }
}
