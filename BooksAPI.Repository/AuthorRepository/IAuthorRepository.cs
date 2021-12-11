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
    public interface IAuthorRepository : IRepository<Genre>
    {
        Task<bool> Create(CreateAuthorCommand command);
        Task<bool> Update(UpdateAuthorCommand command, int Id);
    }
}
