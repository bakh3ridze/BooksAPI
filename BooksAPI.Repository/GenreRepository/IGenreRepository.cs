using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.GenreRepository.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.GenreRepositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<bool> Create(CreateGenreCommand command);
        Task<bool> Update(UpdateGenreCommand command, int Id);
        Task<IEnumerable<Genre>> GetGenresByBookId(int Id);
        Task AddGenresByBookId(int Id, IEnumerable<int>? Ids);
    }
}
