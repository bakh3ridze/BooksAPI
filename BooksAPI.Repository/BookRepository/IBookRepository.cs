using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.BookRepository.Commands;
using BooksAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<bool> Create(CreateBookCommand command);
        Task<bool> Update(UpdateBookCommand command, int Id);
        Task<IEnumerable<DetailedBook>> GetAllDetailed();
        Task<IEnumerable<DetailedBook>> GetAllNotDeletedDetaileds();
        Task<DetailedBook> GetDetailedById(int Id);
        Task<IEnumerable<DetailedBook>> GetDetailedsByAuthorId(int Id);
    }
}
