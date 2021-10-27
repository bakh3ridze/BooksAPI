using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.GenreRepositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly IRepository<Genre> _bookRepository;
        public GenreRepository(BookContext context, IRepository<Genre> bookRepository) : base(context)
        {
            _bookRepository = bookRepository;
        }
    }
}
