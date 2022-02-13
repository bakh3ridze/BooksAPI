using BooksAPI.Data.Entities;
using BooksAPI.Repository.BookRepository.Commands;
using BooksAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK2.BookHttpClient
{
    public interface IBookHttpClient
    {
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<DetailedBook>> GetAllDetailed();
        Task<IEnumerable<DetailedBook>> GetAllNotDeletedDetaileds();
        Task<DetailedBook> GetDetailedById(int Id);
        Task<IEnumerable<DetailedBook>> GetDetailedsByAuthorId(int Id);
        Task Update(int Id, UpdateBookCommand command);
        Task Create(CreateBookCommand command);
        Task RemoveById(int Id);
    }
}
