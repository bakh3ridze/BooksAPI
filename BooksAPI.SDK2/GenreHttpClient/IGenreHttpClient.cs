using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.SDK_.GenreHttpClient
{
    public interface IGenreHttpClient
    {
        Task<IEnumerable<Genre>> GetAll();
    }
}
