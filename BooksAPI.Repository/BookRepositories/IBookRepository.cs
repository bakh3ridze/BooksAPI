using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Details> Details(int Id);
    }
}
