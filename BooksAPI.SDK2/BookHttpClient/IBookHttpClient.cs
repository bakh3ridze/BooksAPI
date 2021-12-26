using BooksAPI.Data.Entities;
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
        Task<IEnumerable<DetailedBook>> GetAllDetailedBook();
    }
}
