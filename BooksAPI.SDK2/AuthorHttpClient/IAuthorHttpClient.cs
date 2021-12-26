using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK2.AuthorHttpClient
{
    public interface IAuthorHttpClient
    {
        Task<IEnumerable<DetailedAuthor>> GetAllDetailed();
        Task<DetailedAuthor> GetDetailedById(int Id);
        Task Create(CreateAuthorCommand command);
        Task Update(int Id, UpdateAuthorCommand command);
        Task RemoveById(int Id);
    }
}
