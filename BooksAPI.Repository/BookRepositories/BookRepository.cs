using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IRepository<Book> _bookRepository;
        public BookRepository(BookContext context, IRepository<Book> bookRepository) : base(context) 
        {
            _bookRepository = bookRepository;
        }
    }
}
