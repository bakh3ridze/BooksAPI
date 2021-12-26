using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthorRepository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<bool> Create(CreateAuthorCommand command);
        Task<bool> Update(UpdateAuthorCommand command, int Id);
        Task<DetailedAuthor> GetDetailedById(int Id);
        Task<IEnumerable<DetailedAuthor>> GetAllDetailed();
    }
}
